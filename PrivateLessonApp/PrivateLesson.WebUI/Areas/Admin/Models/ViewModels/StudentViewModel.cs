﻿using PrivateLesson.Entity.Concrete.Identity;
using PrivateLesson.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrivateLesson.WebUI.Areas.Admin.Models.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad alanı boş bırakılmamalıdır")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad alanı boş bırakılmamalıdır")]
        public string LastName { get; set; }

        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet alanı boş bırakılmamalıdır")]
        public string Gender { get; set; }

        [DisplayName("Doğum Tarihi")]
        [Required(ErrorMessage = "Doğum Tarihi alanı boş bırakılmamalıdır")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Şehir")]
        [Required(ErrorMessage = "Şehir alanı boş bırakılmamalıdır")]
        public string City { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "Telefon Numarası alanı boş bırakılmamalıdır")]
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [DisplayName("Onaylı")]
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "En az bir öğretmen seçilmelidir")]
        public List<TeacherViewModel> Teachers { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
