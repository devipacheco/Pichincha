using Management.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovementController : ControllerBase
    {

        public MovementController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetMovement()
        {

            return NotFound();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMovementById(int Id)
        {

                return BadRequest();
            
        }

        [HttpGet("IdClient")]
        public async Task<IActionResult> GetMovementByIdClient([FromQuery] int IdClient)
        {

                return BadRequest();
            
        }

        [HttpGet("Reports")]
        public async Task<IActionResult> GetMovementByDates(DateTime startDate, DateTime endDate)
        {

                return BadRequest();
        }

        [HttpGet("ReportByClient")]
        public async Task<IActionResult> GetMovementsByClientAndDates(int id,DateTime startDate, DateTime endDate)
        {

                return BadRequest();
            
        }


        [HttpPost]
        public async Task<IActionResult> Create(Movement movement)
        {

                return BadRequest();
            
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, Movement movement)
        {

                return BadRequest();
            
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {

                return BadRequest();
            
        }
    }
}
