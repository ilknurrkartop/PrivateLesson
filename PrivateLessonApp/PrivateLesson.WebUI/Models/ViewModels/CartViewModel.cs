namespace PrivateLesson.WebUI.Models.ViewModels
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public decimal? TotalPrice()
        {
            return CartItems.Sum(ci => ci.ItemPrice * ci.Amount);
        }
    }
}
