using APIREST.Context;
using Microsoft.EntityFrameworkCore;

namespace APIREST.Models.Repository
{
    public class ClienteRepository : IClienteRepository
    {
       
        

        protected readonly ApplicationDbContext _context;
        public ClienteRepository(ApplicationDbContext context) => _context = context;
       
        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Cliente.ToList();
        }

        public Cliente GetClienteById(int id)
        {
            return _context.Cliente.Find(id);
        }
        public async Task<Cliente> CreateClienteAsync(Cliente cliente)
        {
            await _context.Set<Cliente>().AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> UpdateClienteAsync(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClienteAsync(Cliente cliente)
        {
            
            if (cliente is null)
            {
                return false;
            }
            _context.Set<Cliente>().Remove(cliente);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
