using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Business.Abstract
{
    //entity eri�imi engelliyor datan�n �zerinden eri�im sa�l�yor.
    public interface IImageService
    {
        Task CreateAsync(Image image);
        Task<List<Image>> GetAllAsync();
        Task<Image> GetByIdAsync(int id);
        void Update(Image image);
        void Delete(Image image);
        
    }
}
