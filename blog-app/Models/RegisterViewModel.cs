using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blog_app.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="Kullanici Adi")]
        public string? UserName { get; set; }
        [Required]
        [Display(Name ="Ad Soyad")]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name ="Eposta")] 
        public string? Email { get; set; }
        [Required]
        [StringLength(10,ErrorMessage ="{0} alani en az {2} ve {1} karakter araliginda olmalidir.",MinimumLength =5)]
        [DataType(DataType.Password)]
        [Display(Name ="Parola")]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Parolaniz Eslesmiyor.")]
        [Display(Name ="Parola Tekrar")]
        public string? ConfirmPassword { get; set; }
    }
}