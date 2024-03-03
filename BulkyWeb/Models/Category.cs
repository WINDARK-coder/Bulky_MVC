using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models {

    public class Category
    {
        [Key] // it means that Id is primary key
        public int Id { get; set; } // but you also can evade that [Key] because by default it gives primary key for Id or TableNameId
        [Required] // it gives required property for Name column(this column have to be not null or empty)
        public string Name { get; set; }
        public int DisplayOrder { get; set; }

    }

}


