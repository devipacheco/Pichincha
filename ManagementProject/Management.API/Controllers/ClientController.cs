using Management.Domain.Dtos.Client;
using Management.Domain.Interfaces;
using Management.Domain.Others.Result;
using Microsoft.AspNetCore.Mvc;

namespace Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var lst = await _unitOfWork.Clients.GetClients();

            return lst == null ? NotFound() : Ok(lst);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetClientById(int Id)
        {
            var client = await _unitOfWork.Clients.GetClientById(Id);
            return client ==  null || client.Id == 0 ? NotFound() : Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<ResultadoAccion>> Create(ClientDto client)
        {
            try
            {
                var result = await _unitOfWork.Clients.CreateClient(client);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, ClientUpdatedDto client)
        {
            try
            {
                var result = await _unitOfWork.Clients.UpdateCliente(Id, client);

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
                var result = await _unitOfWork.Clients.DeleteCliente(Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
    }
}
