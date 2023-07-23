using Microsoft.EntityFrameworkCore;
using PrivateLesson.Data.Abstract;
using PrivateLesson.Data.Concrete.EfCore.Context;
using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Data.Concrete.EfCore
{
    public class EfCoreCartItemRepository : EfCoreGenericRepository<CartItem>, ICartItemRepository
    {
        public EfCoreCartItemRepository(PrivateLessonContext _appContext) : base(_appContext)
        {
        }
        PrivateLessonContext AppContext
        {
            get { return _dbContext as PrivateLessonContext; }
        }
        public async Task ChangeAmountAsync(CartItem cartItem, int amount)
        {
            cartItem.Amount = amount;
            AppContext.CartItems.Update(cartItem);
            await AppContext.SaveChangesAsync();
        }

        public void ClearCart(int cartId)
        {
            AppContext
                .CartItems
                .Where(ci => ci.CartId == cartId)
                .ExecuteDelete();
        }
    }
}
