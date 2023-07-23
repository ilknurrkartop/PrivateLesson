using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Data.Abstract
{
    public interface IAdvertRepository : IGenericRepository<Advert>
    {
        Task<List<Advert>> GetAdvertsFullDataAsync(string id, bool approvedStatus);
        Task<List<Advert>> GetAllAdvertsAsync(bool approvedStatus);
        Task<int> GetByUrlAsync(string url);
        Task<Advert> GetAdvertFullDataAsync(int id);
    }
}
