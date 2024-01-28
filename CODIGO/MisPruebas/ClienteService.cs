
using APIREST.Models.Repository;

namespace MisPruebas
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository; 

       

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public string ObtenerNombreCliente(int clienteId)
        {
           
            
            var cliente = _clienteRepository.GetClienteById(clienteId);

            if (cliente.clienteid == clienteId)
            {
                return cliente.nombre;
            }
            else
            {
                return $"Cliente con ID {clienteId} no encontrado";
            }
        }

        public Object ObtenerClientes()
        {


            var cliente = _clienteRepository.GetClientes();


            return cliente;
            
        }
    }
}
