using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Range from 1 to 100 only")]
        public int DisplayOrder { get; set; }
        //Set default value whenever an object of DateTime type is created
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;  
    }
}
