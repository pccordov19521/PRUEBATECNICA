namespace APIREST.Models.Repository
{
    public interface ICuentaRepository
    {
        Task<Cuenta> CreateCuentaAsync(Cuenta cuenta);
        Task<bool> DeleteCuentaAsync(Cuenta cuenta);
        Cuenta GetCuentaById(int id);
        IEnumerable<Cuenta> GetCuentas();
       
        Task<bool> UpdateCuentaAsync(Cuenta cuenta);

        void ActualizarSaldo(int cuentaid, decimal nuevosaldo);
        
    }
}
