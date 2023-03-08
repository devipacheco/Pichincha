using Management.Domain.Dtos.Movement;
using Management.Domain.Dtos.Response;
using Management.Domain.Interfaces;
using Management.Domain.Models;
using Management.Domain.Others.Result;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infraestructure.Repositories
{
    internal class MovementRepository : Repository<Movement>, IMovementRepository
    {
        public MovementRepository(DbContextClass context) : base(context)
        {
        }

        public Task<ActionResult<ResultadoAccion>> CreateMovement(MovementDto client)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ResultadoAccion>> DeleteMovement(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<MovementResponseDto> GetMovementById(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<MovementResponseDto>>> GetMovements()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<MovementResponseDto>>> GetMovementsByClientAndDates(int Id, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ResultadoAccion>> UpdateMovement(int Id, MovementUpdatedDto client)
        {
            throw new NotImplementedException();
        }
    }
}
