using BooksAPI.Data;
using BooksAPI.Data.Base;
using BooksAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.BaseRepositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly BookContext _context;
        protected DbSet<T> _entities;
        public Repository(BookContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task<bool> Delete(int Id)
        {
            T? toDelete = await _entities.SingleOrDefaultAsync(x => x.Id == Id);
            if (toDelete != null)
            {
                await Task.Run(() => _entities.Remove(toDelete));
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await _entities.SingleOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Insert(T toInsert)
        {
            if (toInsert != null)
            {
                await _entities.AddAsync(toInsert);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Update(T toUpdate, int Id)
        {
            T? tmp = await _entities.SingleOrDefaultAsync(x => x.Id == Id);
            if (tmp != null)
            {
                await Task.Run(() => _context.Entry(tmp).CurrentValues.SetValues(toUpdate));
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
