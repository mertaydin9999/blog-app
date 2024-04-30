using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace blog_app.Models
{
    public class PostCreateViewModel
    {
        [Required]
        [Display(Name ="Baslik")] 
        public string? Title { get; set; }
         [Required]
        [Display(Name ="Aciklama")]
        public string? Description { get; set; }
        [Required]
        [Display(Name ="Icerik")]
        public string? Content { get; set; }
         [Required]
        [Display(Name ="Url")]
        public string? Url { get; set; }
    }
}