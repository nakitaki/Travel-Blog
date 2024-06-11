using BlogTravel.Models;

namespace BlogTravel.ViewModels
{
    public class CreateAdventureViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
        public AdventureCategory AdventureCategory { get; set; }
    }
}
