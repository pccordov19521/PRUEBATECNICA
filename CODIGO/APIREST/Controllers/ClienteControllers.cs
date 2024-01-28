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
            return _clienteRepository.GetClientes();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetClienteById))]
        public ActionResult<Cliente> GetClienteById(int id)
        {
            var clienteByID = _clienteRepository.GetClienteById(id);
            if (clienteByID == null)
            {
                return NotFound();
            }
            return clienteByID;
        }

        [HttpPost("Crear")]
        [ActionName(nameof(CreateClienteAsync))]
        public async Task<ActionResult<Cliente>> CreateClienteAsync(Cliente cliente)
        {
            cliente.personaid = cliente.clienteid;
            await _clienteRepository.CreateClienteAsync(cliente);
            return CreatedAtAction(nameof(GetClienteById), new { id = cliente.clienteid }, cliente);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateCliente))]
        public async Task<ActionResult> UpdateCliente(int id, Cliente cliente)
        {
            if (id != cliente.clienteid)
            {
                return BadRequest();
            }

            await _clienteRepository.UpdateClienteAsync(cliente);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteCliente))]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = _clienteRepository.GetClienteById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            await _clienteRepository.DeleteClienteAsync(cliente);

            return NoContent();
        }
    }
}
