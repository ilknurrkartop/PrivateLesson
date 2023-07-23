using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Data.Abstract
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        void ClearCart(int cartId);
        Task ChangeAmountAsync(CartItem cartItem, int amount);
    }
}
