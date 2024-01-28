using APIREST.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APIREST.Models.Repository
{
    public class MovimientosRepository : IMovimientosRepository
    {
        protected readonly ApplicationDbContext _context;
        public MovimientosRepository(ApplicationDbContext context) => _context = context;

        public IEnumerable<Movimientos> GetMovimientos()
        {
            return _context.Movimientos.ToList();
        }

        public Movimientos GetMovimientosById(int id)
        {
            return _context.Movimientos.Find(id);
        }
        public async Task<Movimientos> CreateMovimientosAsync(Movimientos movimiento)
        {
            await _context.Set<Movimientos>().AddAsync(movimiento);
            await _context.SaveChangesAsync();
            return movimiento;
        }

        public async Task<bool> UpdateMovimientosAsync(Movimientos movimiento)
        {
            _context.Entry(movimiento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMovimientosAsync(Movimientos movimiento)
        {
            
            if (movimiento is null)
            {
                return false;
            }
            _context.Set<Movimientos>().Remove(movimiento);
            await _context.SaveChangesAsync();

            return true;
        }

        public List<Reporte> ObtenerReporte(DateTime fechaInicio, DateTime fechaFin)
        {
            var parametros = new SqlParameter[]
            {
                new SqlParameter("@fechainicio",fechaInicio),
                new SqlParameter("@fechafin",fechaFin)
            };
       
            var reporte = _context.Reporte.FromSqlRaw("EXEC PRO_OBTENER_REPORTE_MOV @fechainicio,@fechafin", parametros).ToList();   
           return reporte;
        }
    }
}
