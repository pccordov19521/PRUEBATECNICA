using APIREST.Models;
using APIREST.Models.Repository;
using Microsoft.AspNetCore.Mvc;


namespace APIREST.Controllers
{
    [ApiController]
    [Route("cuentas")]
    public class CuentaControllers : ControllerBase
    {
        private readonly ICuentaRepository _cuentaRepository;

        public CuentaControllers(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        [HttpGet("listar")]
        
        [ActionName(nameof(GetCuentasAsync))]
        public IEnumerable<Cuenta> GetCuentasAsync()
        {
            try
            {
                return _cuentaRepository.GetCuentas();
            }

            catch (Exception ex)
            {

                return ((IEnumerable<Cuenta>)BadRequest(ex.Message));
            }
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetCuentaById))]
        public ActionResult<Cuenta> GetCuentaById(int id)
        {
            try
            {

                var cuentaByID = _cuentaRepository.GetCuentaById(id);
                if (cuentaByID == null)
                {
                    return NotFound();
                }
                return cuentaByID;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Crear")]
        [ActionName(nameof(CreateCuentaAsync))]
        public async Task<ActionResult<Cuenta>> CreateCuentaAsync(Cuenta cuenta)
        {
            try
            {

                cuenta.saldofinal = cuenta.saldoinicial;
                await _cuentaRepository.CreateCuentaAsync(cuenta);
                return CreatedAtAction(nameof(GetCuentaById), new { id = cuenta.cuentaid }, cuenta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateCuenta))]
        public async Task<ActionResult> UpdateCuenta(int id, Cuenta cuenta)
        {
            try
            {

                if (id != cuenta.cuentaid)
                {
                    return BadRequest();
                }

                await _cuentaRepository.UpdateCuentaAsync(cuenta);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteCuenta))]
        public async Task<IActionResult> DeleteCuenta(int id)
        {
            try
            {
                var cuenta = _cuentaRepository.GetCuentaById(id);
                if (cuenta == null)
                {
                    return NotFound();
                }

                await _cuentaRepository.DeleteCuentaAsync(cuenta);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
