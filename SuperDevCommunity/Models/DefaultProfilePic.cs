using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SuperDevCommunity.Models
{
    public class DefaultProfilePic
    {
        [Key]
        public int id { get; set; }
        
        [Required(ErrorMessage = "This field is required!")]
        [Display(Name = "Image")]
        [DataType(DataType.ImageUrl)]
        public string imagePath { get; set; }
    }
}