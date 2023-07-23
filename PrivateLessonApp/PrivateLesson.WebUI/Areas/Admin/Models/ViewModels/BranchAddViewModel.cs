using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrivateLesson.WebUI.Areas.Admin.Models.ViewModels
{
    public class BranchAddViewModel
    {
        [DisplayName("Ders Adı")]
        [Required(ErrorMessage = "Ders adı alanı boş bırakılmamalıdır")]
        public string BranchName { get; set; }

        [DisplayName("Ders Açıklaması")]
        [Required(ErrorMessage = "Ders açıklaması alanı boş bırakılmamalıdır")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
    }
}
