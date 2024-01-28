using APIREST.Models.Repository;
using APIREST.Models;
using Xunit;
using Moq;


namespace MisPruebas
{
    public class ClienteServiceTests
    {
        [Fact]
        public void ObtenerClientePorId_DeberiaRetornarClienteCorrecto()
        {
        
            var clienteId = 3;
            var mockClienteRepository = new Mock<IClienteRepository>();
            mockClienteRepository.Setup(repo => repo.GetClienteById(clienteId))
                .Returns(new Cliente { clienteid = 3, genero = "MASCULINO", edad = 20, nombre = "Cliente de prueba"});

            var clienteService = new ClienteService(mockClienteRepository.Object);
          
            var cliente = clienteService.ObtenerNombreCliente(clienteId);

            Assert.NotNull(cliente);
            Assert.Equal("Cliente de prueba", cliente);
        }
        

        [Fact]
        public void ObtenerClientes()
        {
           
            var clienteId = 3;
            
            var mockClienteRepository = new Mock<IClienteRepository>();
            mockClienteRepository.Setup(repo => repo.GetClienteById(clienteId))
              //  .Returns(new Cliente { clienteid = 3, genero = "MASCULINO", edad = 20, nombre = "Cliente de prueba" }
                  //       new Cliente { clienteid = 2, genero = "MASCULINO", edad = 20, nombre = "Cliente de prueba2" });

                  .Returns(new Cliente { clienteid = 3, genero = "MASCULINO", edad = 20, nombre = "Cliente de prueba" });

            var clienteService = new ClienteService(mockClienteRepository.Object);

            var cliente = clienteService.ObtenerClientes();

            Assert.NotNull(cliente);
         
        }
    }
}
