using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Data.Abstract
{
    public interface IGenericRepository<TEntity>
    {
        Task CreateAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();   
        Task<TEntity>GetByIdAsync(int id);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
