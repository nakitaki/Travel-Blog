using BlogTravel.Models;

namespace BlogTravel.ViewModels
{
    public class CreateHolidayViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
        public HolidayCategory HolidayCategory { get; set; }
        //public string AppUserId { get; set; }
    }
}