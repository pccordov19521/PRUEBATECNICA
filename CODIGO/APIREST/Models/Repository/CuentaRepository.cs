using APIREST.Context;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace APIREST.Models.Repository
{
    public class CuentaRepository : ICuentaRepository
    {
        protected readonly ApplicationDbContext _context;
        public CuentaRepository(ApplicationDbContext context) => _context = context;

        public void ActualizarSaldo(int cuentaid , decimal valor)
        {
            var cuenta = _context.Cuenta.Find(cuentaid);
            if ( cuenta != null)
            {
                cuenta.saldofinal+=valor;
                _context.SaveChanges();

            }

        }

     

        
        public IEnumerable<Cuenta> GetCuentas()
        {
            return _context.Cuenta.ToList();
        }

        public Cuenta GetCuentaById(int id)
        {
            return _context.Cuenta.Find(id);
        }
        public async Task<Cuenta> CreateCuentaAsync(Cuenta cuenta)
        {
            await _context.Set<Cuenta>().AddAsync(cuenta);
            await _context.SaveChangesAsync();
            return cuenta;
        }

        public async Task<bool> UpdateCuentaAsync(Cuenta cuenta)
        {
            _context.Entry(cuenta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCuentaAsync(Cuenta cuenta)
        {
            
            if (cuenta is null)
            {
                return false;
            }
            _context.Set<Cuenta>().Remove(cuenta);
            await _context.SaveChangesAsync();

            return true;
        }

      
    }
}
