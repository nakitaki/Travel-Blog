using BlogTravel.Data;
using BlogTravel.Interfaces;
using BlogTravel.Models;
using BlogTravel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogTravel.Controllers
{
    public class HolidayController : Controller
    {
        private readonly IHolidayRepository _holidayRepository;
        private readonly IPhotoService _photoService;

        public HolidayController(IHolidayRepository holidayRepository, IPhotoService photoService)
        {
            _holidayRepository = holidayRepository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Holiday> holidays = await _holidayRepository.GetAll();
            return View(holidays);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Holiday holiday = await _holidayRepository.GetByIdAsync(id);
            return View(holiday);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHolidayViewModel holidayVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(holidayVM.Image);
                var holiday = new Holiday
                {
                    Title = holidayVM.Title,
                    Description = holidayVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        City = holidayVM.Address.City,
                        Street = holidayVM.Address.Street
                    }
                };
                _holidayRepository.Add(holiday);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(holidayVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var holiday = await _holidayRepository.GetByIdAsync(id);
            if (holiday == null) return View("Error");
            var holidayVM = new EditHolidayViewModel
            {
                Title = holiday.Title,
                Description = holiday.Description,
                AddressId = holiday.AddressId,
                Address = holiday.Address,
                URL = holiday.Image,
                HolidayCategory = holiday.HolidayCategory
            };
            return View(holidayVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditHolidayViewModel holidayVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit holiday");
                return View("Edit", holidayVM);
            }

            var userHoliday = await _holidayRepository.GetByIdAsyncNoTracking(id);

            if(userHoliday != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userHoliday.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(holidayVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(holidayVM.Image);

                var holiday = new Holiday
                {
                    Id = id,
                    Title = holidayVM.Title,
                    Description = holidayVM.Description,
                    Image = photoResult.Url.ToString(),
                    AddressId = holidayVM.AddressId,
                    Address = holidayVM.Address
                };

                _holidayRepository.Update(holiday);
                return RedirectToAction("Index");
            }
            else
            {
                return View(holidayVM);
            }
            
        }
    }
}
