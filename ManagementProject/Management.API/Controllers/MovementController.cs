using Management.Domain.Models;
using Management.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovementController : ControllerBase
    {
        public readonly IMovementService _movementService;

        public MovementController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovement()
        {

            var movements = await _movementService.GetAll();

            return movements == null ? NotFound() : Ok(movements);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMovementById(int Id)
        {
            var movement = await _movementService.GetById(Id);

            if (movement != null)
            {
                return Ok(movement);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("IdClient")]
        public async Task<IActionResult> GetMovementByIdClient([FromQuery] int IdClient)
        {
            var movement = await _movementService.GetByIdClient(IdClient);

            if (movement != null)
            {
                return Ok(movement);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("Reports")]
        public async Task<IActionResult> GetMovementByDates(DateTime startDate, DateTime endDate)
        {
            var movement = await _movementService.GetByDates(startDate, endDate);

            if (movement != null)
            {
                return Ok(movement);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("ReportByClient")]
        public async Task<IActionResult> GetMovementsByClientAndDates(int id,DateTime startDate, DateTime endDate)
        {
            var movements = await _movementService.GetByClientAndDates(id, startDate, endDate);

            if (movements != null)
            {
                return Ok(movements);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(Movement movement)
        {
            var isMovementCreated = await _movementService.Create(movement);

            if (isMovementCreated)
            {
                return Ok(isMovementCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Movement movement)
        {
            if (movement != null)
            {
                var isMovementUpdated = await _movementService.Update(movement);
                if (isMovementUpdated)
                {
                    return Ok(isMovementUpdated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var isMovementDeleted = await _movementService.Delete(Id);

            if (isMovementDeleted)
            {
                return Ok(isMovementDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
