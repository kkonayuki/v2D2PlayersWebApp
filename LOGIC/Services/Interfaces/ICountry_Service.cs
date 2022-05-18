using LOGIC.Services.Models;
using LOGIC.Services.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface ICountry_Service
    {
        Task<Generic_ResultSet<Country_ResultSet>> AddCountry(string name);
        Task<Generic_ResultSet<List<Country_ResultSet>>> GetAllCountries();
        Task<Generic_ResultSet<Country_ResultSet>> UpdateCountry(int id, string name);
    }
}
