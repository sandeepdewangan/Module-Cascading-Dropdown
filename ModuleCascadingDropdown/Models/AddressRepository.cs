using ModuleCascadingDropdown.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleCascadingDropdown.Models
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _db;

        public AddressRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<Country> GetAllCountries()
        {
            var query = from countries in _db.Country
                        select countries;
            var content = query.ToList<Country>();
            return content;
        }
        public IList<State> GetAllStatesByCountryId(int countryId)
        {
            var query = from states in _db.State
                        where states.CountryId == countryId
                        select states;
            var content = query.ToList<State>();
            return content;
        }
    }
}
