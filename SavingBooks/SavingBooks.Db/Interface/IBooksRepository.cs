using DB.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Interface
{
    public interface IBooksRepository
    {
        IQueryable<Book> QueryAll();
        Task Add(Book book);
        Task Delete(int id);
        Task Update(Book book);
        Task<Book> GetById(int id);
    }
}
