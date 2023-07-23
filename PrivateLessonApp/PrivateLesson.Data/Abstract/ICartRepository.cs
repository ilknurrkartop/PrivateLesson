using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Data.Abstract
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart> GetCartByUserId(string userId);
        Task AddToCart(string userId, int teacherId, int amount);
    }
}
