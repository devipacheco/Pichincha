using Management.Domain.Dtos.Account;
using Management.Domain.Dtos.Movement;
using Management.Domain.Dtos.Response;
using Management.Domain.Models;
using Management.Domain.Others.Result;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Interfaces
{
    public interface IMovementRepository : IRepository<Movement>
    {
        Task<ActionResult<List<MovementResponseDto>>> GetMovements();
        Task<ActionResult<List<MovementResponseDto>>> GetMovementsByClientAndDates(int Id, DateTime start, DateTime end);
        Task<MovementResponseDto> GetMovementById(int clientId);
        Task<ActionResult<ResultadoAccion>> CreateMovement(MovementDto client);
        Task<ActionResult<ResultadoAccion>> UpdateMovement(int Id, MovementUpdatedDto client);
        Task<ActionResult<ResultadoAccion>> DeleteMovement(int Id);
    }
}
