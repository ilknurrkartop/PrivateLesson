using PrivateLesson.Entity.Concrete;
using System.ComponentModel.DataAnnotations;

namespace PrivateLesson.WebUI.Models.ViewModels
{
    public class CartItemViewModel
    {
        public int CartItemId { get; set; }
        public int AdvertId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherGraduation { get; set; }
        public string TeacherUrl { get; set; }
        public string BranchName { get; set; }
        public decimal? ItemPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz")]
        [Range(1, 10)]
        public int Amount { get; set; }
    }
}
