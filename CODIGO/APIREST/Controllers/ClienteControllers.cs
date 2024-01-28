using APIREST.Models;
using APIREST.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIREST.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteControllers : ControllerBase
    {
       
        private readonly IClienteRepository _clienteRepository;

        public ClienteControllers(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("listar")]
        [ActionName(nameof(GetClientesAsync))]
        public IEnumerable<Cliente> GetClientesAsync()
        {
            try
            {
                return _clienteRepository.GetClientes();
            }
            catch (Exception ex)
            {

                return (IEnumerable<Cliente>)BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetClienteById))]
        public ActionResult<Cliente> GetClienteById(int id)
        {

            try
            {
                var clienteByID = _clienteRepository.GetClienteById(id);
                if (clienteByID == null)
                {
                    return NotFound();
                }
                return clienteByID;
            }
            catch (Exception ex)
            {

                return (BadRequest(ex.Message));
            }
        }

        [HttpPost("Crear")]
        [ActionName(nameof(CreateClienteAsync))]
        public async Task<ActionResult<Cliente>> CreateClienteAsync(Cliente cliente)
        {
            try
            {
                
                await _clienteRepository.CreateClienteAsync(cliente);
                return CreatedAtAction(nameof(GetClienteById), new { id = cliente.clienteid }, cliente);
            }
            catch (Exception ex)
            {

                return (BadRequest(ex.Message));
            }
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateCliente))]
        public async Task<ActionResult> UpdateCliente(int id, Cliente cliente)
        {

            try
            {

               if (id != cliente.clienteid)
                {
                    return BadRequest();
                }

                await _clienteRepository.UpdateClienteAsync(cliente);

                return NoContent();
            }
            catch (Exception ex)
            {

                return (BadRequest(ex.Message));
            }

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteCliente))]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {


                var cliente = _clienteRepository.GetClienteById(id);
                if (cliente == null)
                {
                    return NotFound();
                }

                await _clienteRepository.DeleteClienteAsync(cliente);

                return NoContent();
            }
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));
            }
        }
    }
}
