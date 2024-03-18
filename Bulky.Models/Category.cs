using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{

    public class Category
    {
        [Key] // it means that Id is primary key
        public int Id { get; set; } // but you also can evade that [Key] because by default it gives primary key for Id or TableNameId
        [Required] // it gives required property for Name column(this column have to be not null or empty)
        [DisplayName("Category Name")] // gives you permission for editing name that will be displayed
        [MaxLength(30)] // limits the data by 30 characters
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1-100")] // limits the data between 1 and 100, and also you can customize your error message 
        public int DisplayOrder { get; set; }

    }

}


