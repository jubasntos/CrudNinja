using System.Threading.Tasks;
using CrudNinja.Domain;

namespace CrudNinja.Repository
{
    public class CrudNinjaPersistence : ICrudNinjaPersistence
    {
        private readonly NinjaContext _context;
        public CrudNinjaPersistence(NinjaContext _context)
        {
            this._context = _context;

        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void DeleRange<T>(T[] entity) where T : class
        {
            _context.RemoveRange(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}