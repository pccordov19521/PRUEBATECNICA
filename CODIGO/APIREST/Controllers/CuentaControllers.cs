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
            return _cuentaRepository.GetCuentas();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetCuentaById))]
        public ActionResult<Cuenta> GetCuentaById(int id)
        {
            var cuentaByID = _cuentaRepository.GetCuentaById(id);
            if (cuentaByID == null)
            {
                return NotFound();
            }
            return cuentaByID;
        }

        [HttpPost("Crear")]
        [ActionName(nameof(CreateCuentaAsync))]
        public async Task<ActionResult<Cuenta>> CreateCuentaAsync(Cuenta cuenta)
        {
            cuenta.saldofinal = cuenta.saldoinicial;
            await _cuentaRepository.CreateCuentaAsync(cuenta);
            return CreatedAtAction(nameof(GetCuentaById), new { id = cuenta.cuentaid }, cuenta);

        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateCuenta))]
        public async Task<ActionResult> UpdateCuenta(int id, Cuenta cuenta)
        {
            if (id != cuenta.cuentaid)
            {
                return BadRequest();
            }

            await _cuentaRepository.UpdateCuentaAsync(cuenta);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteCuenta))]
        public async Task<IActionResult> DeleteCuenta(int id)
        {
            var cuenta = _cuentaRepository.GetCuentaById(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            await _cuentaRepository.DeleteCuentaAsync(cuenta);

            return NoContent();
        }


    }
}
