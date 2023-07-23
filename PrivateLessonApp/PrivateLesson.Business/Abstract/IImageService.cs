using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Business.Abstract
{
    //entity eriþimi engelliyor datanýn üzerinden eriþim saðlýyor.
    public interface IImageService
    {
        Task CreateAsync(Image image);
        Task<List<Image>> GetAllAsync();
        Task<Image> GetByIdAsync(int id);
        void Update(Image image);
        void Delete(Image image);
        
    }
}
