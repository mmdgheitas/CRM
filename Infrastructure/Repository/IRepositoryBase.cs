using Infrastructure.Entity;
using Infrastructure.Service.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryBase<T, t>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllAsync();
        IQueryable<T> GetAllQueryable();
        bool Insert(T entity);
        Task<bool> InsertAsync(T entity);
        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);
        bool Delete(t id);
        Task<bool> DeleteAsync(t id);
        bool Delete2(t id);
        List<T> SqlQuery(string query);
        List<T> FromSql(FormattableString query);
        //  Task<List<T>> SqlQueryAsync(string query);

        bool Insert2(T entity);//only for insert visitor
        Task<bool> Insert2Async(T entity);//only for insert visitor
        bool Update2(T entity);//only for update visitor
        Task<bool> Update2Async(T entity);

    }
}
