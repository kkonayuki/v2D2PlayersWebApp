using DAL.Entities;
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class Country_Service : ICountry_Service
    {
        private ICRUD _crud = new CRUD();

        public async Task<Generic_ResultSet<Country_ResultSet>> AddCountry(string name)
        {
            Generic_ResultSet<Country_ResultSet> result = new Generic_ResultSet<Country_ResultSet>();
            try
            {
                Country Country = new Country
                {
                    Name = name,
                };

                Country = await _crud.Create<Country>(Country);

                Country_ResultSet countryAdded = new Country_ResultSet
                {
                    id = Country.Id,
                    name = Country.Name
                };

                result.userMessage = String.Format("The supplied country {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Country_Service: AddCountry() method executed successfuly.";
                result.result_set = countryAdded;
                result.success = true;

            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed to register your information for the country supplied. Please try again.";
                result.internalMessage = String.Format("ERROR: LOGIC.Services.Implementation.Country_Service: AddCountry(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Country_ResultSet>>> GetAllCountries()
        {
            Generic_ResultSet<List<Country_ResultSet>> result = new Generic_ResultSet<List<Country_ResultSet>>();
            try
            {
                List<Country> Countries = await _crud.ReadAll<Country>();

                result.result_set = new List<Country_ResultSet>();
                Countries.ForEach(cg => {
                    result.result_set.Add(new Country_ResultSet
                    {
                        id = cg.Id,
                        name = cg.Name,
                    });
                });

                result.userMessage = String.Format("All countries obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Country_Service: GetAllCountries() method executed successfuly.";
                result.success = true;
            }
            catch(Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed fetch all the required countries from the database";
                result.internalMessage = String.Format("ERROR: LOGIC.Services.Implementation.Country_Service: GetAllCountries(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<Country_ResultSet>> UpdateCountry(int id, string name)
        {
            Generic_ResultSet<Country_ResultSet> result = new Generic_ResultSet<Country_ResultSet>();
            try
            {
                Country Country = new Country
                {
                    Id = id,
                    Name = name
                };

                Country = await _crud.Update<Country>(Country, id);

                Country_ResultSet countryUpdated = new Country_ResultSet
                {
                    id = Country.Id,
                    name = Country.Name
                };

                result.userMessage = String.Format("The supplied Country {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Country_Service: UpdateCountry() method executed successfuly.";
                result.result_set = countryUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception= exception;
                result.userMessage = "We failed to update your information for the country supplied. Please try again.";
                result.internalMessage = String.Format("ERROR: LOGIC.Implementations.Country_Service: UpdateCountry(): {0}", exception.Message);
            }
            return result;
        }
    }
}
