using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using blog_app.Entity;

namespace blog_app.Models
{
    public class PostCreateViewModel
    {
        public int PostId { get; set; }
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
        public bool IsActive { get; set; }
        public List<Tag> Tags { get; set; }=new();
    }
}