using System.Threading.Tasks;
using CrudNinja.Domain;

namespace CrudNinja.Repository
{
    public interface ICrudNinjaPersistence
    {
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         void DeleRange<T>(T[] entity) where T: class;
         Task<bool> SaveChangesAsync();

         /*Task<Pedido[]> GetAllEventosByTemaAsync(string tema);*/

    }
}