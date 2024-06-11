using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogTravel.Models
{
    public class AppUser : IdentityUser
    {
        public int? Pace { get; set; }
        public int? Mileage {  get; set; }

        [ForeignKey("Address")]
        public int? AddressId {  get; set; }
        public Address? Address { get; set; }

        public ICollection<Holiday> Holidays { get; set; }
        public ICollection<Adventure> Adventures { get; set; }
    }
}
