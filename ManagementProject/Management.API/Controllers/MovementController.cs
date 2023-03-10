using Management.Domain.Dtos.Movement;
using Management.Domain.Interfaces;
using Management.Domain.Models;
using Management.Domain.Others.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovementController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovements()
        {
            var lst = await _unitOfWork.Movements.GetMovements();

            return lst == null ? NotFound() : Ok(lst);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMovementById(int Id)
        {
            var movement = await _unitOfWork.Movements.GetMovementById(Id);
            return movement == null || movement.Id == 0 ? NotFound() : Ok(movement);
        }

        [HttpGet("GetByClientId/{Id}")]
        public async Task<IActionResult> GetMovementByIdClient(int Id)
        {
            var movements = await _unitOfWork.Movements.GetMovementsByClientId(Id);
            return movements.Count == 0 ? NotFound() : Ok(movements);
        }

        [HttpGet("ReportsByDates")]
        public async Task<IActionResult> GetMovementByDates(DateTime startDate, DateTime endDate)
        {
            var movements = await _unitOfWork.Movements.GetMovementsByDates(startDate, endDate);
            return movements.Count == 0 ? NotFound() : Ok(movements);
        }

        [HttpGet("ReportByClientAndDates")]
        public async Task<ActionResult> GetMovementsByClientAndDates([FromQuery] int clientId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var movements = await _unitOfWork.Movements.GetMovementsByClientAndDates(clientId, startDate, endDate);
            return movements.Count == 0 ? NotFound() : Ok(movements);
        }

        [HttpPost]
        public async Task<ActionResult<ResultadoAccion>> Create(MovementDto movement)
        {
            try
            {
                var result = await _unitOfWork.Movements.CreateMovement(movement);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, MovementUpdatedDto movement)
        {
            try
            {
                var result = await _unitOfWork.Movements.UpdateMovement(Id, movement);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var result = await _unitOfWork.Movements.DeleteMovement(Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
    }
}
