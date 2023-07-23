using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Business.Abstract
{
    public interface ICartService
    {
        Task<Cart> GetCartByUserId(string userId);
        Task AddToCart(string userId, int advertId, int amount);
        Task InitializeCart(string userId);

    }
}
