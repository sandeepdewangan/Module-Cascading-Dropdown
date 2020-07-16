using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleCascadingDropdown.Models
{
    public class AddressModel
    {
        public AddressModel()
        {
            AvailableCountries = new List<SelectListItem>();
            AvailableStates = new List<SelectListItem>();
        }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public IList<SelectListItem> AvailableCountries { get; set; }
        [Display(Name = "State")]
        public int StateId { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }
    }
}
