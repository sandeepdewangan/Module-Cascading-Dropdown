using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleCascadingDropdown.Models
{
    public interface IAddressRepository
    {
        IList<Country> GetAllCountries();
        IList<State> GetAllStatesByCountryId(int countryId);
    }
}
