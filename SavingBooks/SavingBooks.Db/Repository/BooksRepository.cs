using DB.Interface;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AppContext _dbContext;

        public BooksRepository(AppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Book> QueryAll()
        {
            return _dbContext.Books.AsQueryable();
        }

        public async Task<Book> GetById(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);

            if (book == null)
            {
                throw new KeyNotFoundException(nameof(Book));
            }

            return book;
        }

        public async Task Add(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Book book)
        {
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var _book = await _dbContext.Books.FirstOrDefaultAsync(b => b.BookId == id);
            if (_book != null)
            {
                _dbContext.Books.Remove(_book);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
