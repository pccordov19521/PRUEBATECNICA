namespace APIREST.Models.Repository
{
    public interface IMovimientosRepository
    {
        Task<Movimientos> CreateMovimientosAsync(Movimientos movimiento);
        Task<bool> DeleteMovimientosAsync(Movimientos movimiento);
        Movimientos GetMovimientosById(int id);
        IEnumerable<Movimientos> GetMovimientos();
       
        Task<bool> UpdateMovimientosAsync(Movimientos movimiento);

        List<Reporte> ObtenerReporte(DateTime fechainicio, DateTime fechafin);
    }
}
