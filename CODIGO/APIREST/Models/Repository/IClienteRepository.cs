namespace APIREST.Models.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> CreateClienteAsync(Cliente cliente);
        Task<bool> DeleteClienteAsync(Cliente cliente);
        Cliente GetClienteById(int id);
        IEnumerable<Cliente> GetClientes();
        Task<bool> UpdateClienteAsync(Cliente cliente);


    }
}
