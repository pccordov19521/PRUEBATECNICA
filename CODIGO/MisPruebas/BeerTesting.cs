using APIREST.Models.Repository;
using Xunit;
using Moq;
using APIREST.Controllers;
using Microsoft.AspNetCore.Mvc;
using APIREST.Context;

namespace MisPruebas
{
    public class BeerTesting
    {
        private readonly ClienteControllers _controller;
        private readonly IClienteRepository _clienteRepository;

        //public BeerTesting(ClienteRepository _clienteRepository)

        protected readonly ApplicationDbContext _context;
        //public void ClienteRepository(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
       
        public BeerTesting()
        {
            _clienteRepository = new ClienteRepository(_context);
            // _clienteRepository = _clienteRepository;
            _controller = new ClienteControllers(_clienteRepository);
        }
       

        [Fact]

        public void Get_Ok()
        {
       
            var result = _controller.GetClientesAsync();
            Assert.IsType<OkObjectResult>(result);

        }


    }
}
