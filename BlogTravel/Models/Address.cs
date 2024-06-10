using System.ComponentModel.DataAnnotations;

namespace BlogTravel.Models
{
    public class Address
    {
        [Key]
        public int Id {  get; set; }
        public String Street {  get; set; }
        public String City {  get; set; }


    }
}
