using AutoMapper;
using FluentValidation;
using Management.API.Dtos.Response;
using Management.Domain.Dtos.Account;
using Management.Domain.Dtos.Client;
using Management.Domain.Dtos.Movement;
using Management.Domain.Dtos.Response;
using Management.Domain.Enums;
using Management.Domain.Interfaces;
using Management.Domain.Models;
using Management.Domain.Others.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infraestructure.Repositories
{
    internal class MovementRepository : Repository<Movement>, IMovementRepository
    {
        private readonly DbContextClass _dbContext;
        private readonly IValidator<MovementDto> _validator;
        private readonly IValidator<MovementUpdatedDto> _validatorUpdate;
        private readonly IMapper _mapper;

        public MovementRepository(DbContextClass context, IMapper mapper, IValidator<MovementDto> validator, IValidator<MovementUpdatedDto> validatorUpdated) : base(context)
        {
            _dbContext = context;
            _mapper = mapper;
            _validator = validator;
            _validatorUpdate = validatorUpdated;
        }

        public async Task<ActionResult<ResultadoAccion>> DeleteMovement(int Id)
        {
            try
            {
                var _movement = await _dbContext.Movements.FirstAsync(x => x.Id == Id);

                _movement.Status = false;

                return Update(_movement);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<MovementResponseDto>> GetMovementsByClientId(int Id)
        {
            var result = await _dbContext.Movements.Include(x => x.Account).Include(x => x.Account.Client).Where(x => x.Account.ClientId == Id).ToListAsync();

            return result != null ? _mapper.Map<List<Movement>, List<MovementResponseDto>>(result) : new List<MovementResponseDto>();
        }

        public async Task<MovementResponseDto> GetMovementById(int Id)
        {
            var result = await _dbContext.Movements.Include(x => x.Account).Include(x => x.Account.Client).FirstAsync(x => x.Id == Id);

            return result != null ? _mapper.Map<Movement, MovementResponseDto>(result) : new MovementResponseDto();
        }

        public async Task<List<MovementResponseDto>> GetMovements()
        {
            var movements = await _dbContext.Movements.Include(x => x.Action).Include(x => x.Account).Include(x => x.Account.Client).Include(x => x.Account.Client.Person).Where(x => x.Status).ToListAsync();
            var movementsMapper = _mapper.Map<List<Movement>, List<MovementResponseDto>>(movements);

            return movementsMapper;
        }

        public async Task<List<MovementResponseDto>> GetMovementsByClientAndDates(int Id, DateTime start, DateTime end)
        {
            var movements = await _dbContext.Movements.Include(x => x.Action)
                                                      .Include(x => x.Account)
                                                      .Include(x => x.Account.Client)
                                                      .Include(x => x.Account.Client.Person)
                                                      .Where(x => x.Status && x.Account.ClientId == Id)
                                                      .Where(x => x.CreatedDate.Date >= start.Date)
                                                      .Where(x => x.CreatedDate.Date <= end.AddDays(1).Date)
                                                      .ToListAsync();
            var movementsMapper = _mapper.Map<List<Movement>, List<MovementResponseDto>>(movements);

            return movementsMapper;
        }

        public async Task<List<MovementResponseDto>> GetMovementsByDates(DateTime start, DateTime end)
        {
            var movements = await _dbContext.Movements.Include(x => x.Account)
                                                                 .Where(x => x.Status && x.CreatedDate >= start && x.CreatedDate <= end.AddDays(1))
                                                                 .ToListAsync();
            var movementsMapper = _mapper.Map<List<Movement>, List<MovementResponseDto>>(movements);

            return movementsMapper;
        }

        public async Task<ActionResult<ResultadoAccion>> UpdateMovement(int Id, MovementUpdatedDto mov)
        {
            try
            {
                var result = await _validatorUpdate.ValidateAsync(mov);

                if (!result.IsValid)
                {
                    return new ResultadoAccion(false, result.ToString());
                }

                // Obtenemos la cuenta del movimiento
                var _mov = await _dbContext.Movements.FirstOrDefaultAsync(x => x.Id == Id);

                if (_mov != null)
                {
                    var movementToUpdated = _mapper.Map<MovementUpdatedDto, Movement>(mov);

                    _mov.Status = movementToUpdated.Status;
                    _mov.UpdatedDate = DateTime.Now;
                    _mov.UpdatedBy = "UserCurrentLoggued";

                    return Update(movementToUpdated);
                }
                else
                    return new ResultadoAccion(false, "Movimiento no encontrado.");
            }


            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<ResultadoAccion>> CreateMovement(MovementDto mov)
        {
            try
            {
                var result = await _validator.ValidateAsync(mov);

                if (!result.IsValid)
                {
                    return new ResultadoAccion(false, result.ToString());
                }

                var movementToInsert = _mapper.Map<MovementDto, Movement>(mov);

                // Obtenemos la cuenta del movimiento
                var _mov = await _dbContext.Movements.OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync(x => x.AccountId == movementToInsert.AccountId);

                double _currentBalance = 0;
                double balance = 0;

                // Traemos el balance de la cuenta
                if (_mov == null)
                {
                    var _account = await _dbContext.Accounts.FirstAsync(x => x.Id == movementToInsert.AccountId);
                    balance = _account.InitialBalance;
                }
                else // Treamos el ultimo Balance del ultimo movimiento realizado con la cuenta
                {
                    balance = _mov.Balance;
                }

                // Verificamos el tipo de movimiento a realizar.
                if (movementToInsert.ActionId == (int)MovementTypeEnum.Debito)
                {
                    if (balance < mov.Import)
                    {
                        return new ResultadoAccion(false, "Saldo no disponible");
                    }
                    _currentBalance = balance - mov.Import;
                }
                else
                {
                    _currentBalance = balance + mov.Import;
                }

                // Actualizamos el saldo disponible en la cuenta.
                movementToInsert.CreatedDate = DateTime.Now;
                movementToInsert.CreatedBy = "UserCurrentLoggued";
                movementToInsert.Balance = _currentBalance;
                movementToInsert.Description = $"{(MovementTypeEnum)movementToInsert.ActionId} de {mov.Import}";

                return await Add(movementToInsert);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
