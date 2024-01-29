using APIREST.Models.Repository;
using Xunit;
using Moq;
using APIREST.Controllers;
using Microsoft.AspNetCore.Mvc;
using APIREST.Context;
using APIREST.Models;

namespace MisPruebas
{
    public class ReporteTesting
    {

        private readonly MovimientosControllers _controller;
        private readonly IMovimientosRepository _service;
        private readonly ICuentaRepository _servicec;
        protected readonly ApplicationDbContext _context;

     
      //  public MovimientosRepository(ApplicationDbContext context) => _context = context;

        public ReporteTesting()
        {
            _service = new MovimientosRepository( _context);

            _controller = new MovimientosControllers(_service, _servicec);
        }

        

        [Fact]

        public void Retorno_mi_Reporte_Ok()
        {
            DateTime fechai = DateTime.Now.AddDays(-10);
            DateTime fechaf = DateTime.Now.AddDays(1);
         
            var reporte = _controller.GenerarReporte(fechai, fechaf);
     
            Assert.NotNull(reporte);

        }


    }
}
