using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ModuleCascadingDropdown.Models;

namespace ModuleCascadingDropdown.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAddressRepository _addressRepo;

        public HomeController(ILogger<HomeController> logger, IAddressRepository addressRepo)
        {
            _logger = logger;
            _addressRepo = addressRepo;
        }

        public IActionResult Index()
        {
            AddressModel model = new AddressModel();
            model.AvailableCountries.Add(new SelectListItem
            { Text = "-Please select-", Value = "Selects items" });
            var countries = _addressRepo.GetAllCountries();
            foreach (var country in countries)
            {
                model.AvailableCountries.Add(new SelectListItem()
                {
                    Text = country.Name,
                    Value = country.Id.ToString()
                });
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public ActionResult GetStatesByCountryId(string countryId)
        {
            if (String.IsNullOrEmpty(countryId))
            {
                throw new ArgumentNullException("countryId");
            }
            int id = 0;
            bool isValid = Int32.TryParse(countryId, out id);
            var states = _addressRepo.GetAllStatesByCountryId(id);
            var result = (from s in states
                          select new
                          {
                              id = s.Id,
                              name = s.Name
                          }).ToList();
            return Json(new { data = result });
        }
    }
}
