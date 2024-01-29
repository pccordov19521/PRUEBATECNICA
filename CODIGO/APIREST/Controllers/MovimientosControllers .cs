using APIREST.Models;
using APIREST.Models.Repository;
using Microsoft.AspNetCore.Mvc;


namespace APIREST.Controllers
{
    [ApiController]
    [Route("movimientos")]
    public class MovimientosControllers : ControllerBase
    {
        private readonly IMovimientosRepository _movimientoRepository;
        private readonly ICuentaRepository _cuentaRepository;

        public MovimientosControllers(IMovimientosRepository movimientoRepository, ICuentaRepository cuentaRepository)
        {
            _movimientoRepository = movimientoRepository;
            _cuentaRepository = cuentaRepository;
        }

        [HttpGet("listar")]
        [ActionName(nameof(GetMovimientosAsync))]
        public IEnumerable<Movimientos> GetMovimientosAsync()
        {
            try
            {
                return _movimientoRepository.GetMovimientos();
            }
            catch (Exception ex)
            {
                return (IEnumerable<Movimientos>)BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetMovimientosById))]
        public ActionResult<Movimientos> GetMovimientosById(int id)
        {
            try
            {
                var movimientoByID = _movimientoRepository.GetMovimientosById(id);
                if (movimientoByID == null)
                {
                    return NotFound();
                }
                return movimientoByID;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Crear")]
        [ActionName(nameof(CreateMovimientosAsync))]
        public async Task<ActionResult<Movimientos>> CreateMovimientosAsync(Movimientos movimiento)
        {
            try
            {
                var cuenta = _cuentaRepository.GetCuentaById(movimiento.cuentaid);
                if (cuenta.saldofinal + movimiento.valor < 0)
                {
                    movimiento.tipomovimiento = "Error Saldo Insuficiente";
                    movimiento.saldo = cuenta.saldofinal;
                    return movimiento;

                }
                else
                {
                    movimiento.saldo = cuenta.saldofinal + movimiento.valor;
                    await _movimientoRepository.CreateMovimientosAsync(movimiento);

                    _cuentaRepository.ActualizarSaldo(movimiento.cuentaid, movimiento.valor);
                    return CreatedAtAction(nameof(GetMovimientosById), new { id = movimiento.movimientosid }, movimiento);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateMovimientos))]
        public async Task<ActionResult> UpdateMovimientos(int id, Movimientos movimiento)
        {
            try
            {
                if (id != movimiento.cuentaid)
                {
                    return BadRequest();
                }

                await _movimientoRepository.UpdateMovimientosAsync(movimiento);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteMovimientos))]
        public async Task<IActionResult> DeleteMovimientos(int id)
        {
            try
            {
                var movimiento = _movimientoRepository.GetMovimientosById(id);
                if (movimiento == null)
                {
                    return NotFound();
                }

                await _movimientoRepository.DeleteMovimientosAsync(movimiento);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("reporte")]
        
        public IActionResult GenerarReporte(DateTime fechainicio , DateTime fechafin)
        {
            try
            {
                var reporte = _movimientoRepository.ObtenerReporte(fechainicio, fechafin);
                return Ok(reporte);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            
            }

        }

        
    }
}
