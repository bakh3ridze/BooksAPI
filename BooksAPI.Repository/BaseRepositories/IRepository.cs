using BooksAPI.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksAPI.Repository.BaseRepositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
        Task<bool> Insert(T toInsert);
        Task<bool> Delete(int Id);
        Task<bool> Update(T toUpdate, int Id);
    }
}
