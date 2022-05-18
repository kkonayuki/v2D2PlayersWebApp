using DAL.Entities;
using DAL.Entities.Enums;
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class Team_Service : ITeam_Service
    {
        private ICRUD _crud = new CRUD();
        public async Task<Generic_ResultSet<Team_ResultSet>> AddTeam(string name, Region region)
        {
            Generic_ResultSet<Team_ResultSet> result = new Generic_ResultSet<Team_ResultSet>();
            try
            {
                Team Team = new Team
                {
                    Name = name,
                    Region = region
                };

                Team = await _crud.Create<Team>(Team);

                Team_ResultSet teamAdded = new Team_ResultSet
                {
                    id = Team.Id,
                    name = Team.Name,
                    region = Team.Region
                };

                result.userMessage = String.Format("The supplied Team {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Team_Service: AddTeam() method executed successfuly.";
                result.result_set = teamAdded;
                result.success = true;

            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed to register your information for the team supplied. Please try again.";
                result.internalMessage = String.Format("ERROR: LOGIC.Services.Implementation.Team_Service: AddTeam(): {0}", exception.Message);
            }
            return result;

        }

        public async Task<Generic_ResultSet<List<Team_ResultSet>>> GetAllTeams()
        {
            Generic_ResultSet<List<Team_ResultSet>> result = new Generic_ResultSet<List<Team_ResultSet>>();
            try
            {
                List<Team> Countries = await _crud.ReadAll<Team>();

                result.result_set = new List<Team_ResultSet>();
                Countries.ForEach(cg => {
                    result.result_set.Add(new Team_ResultSet
                    {
                        id = cg.Id,
                        name = cg.Name,
                        region = cg.Region
                    });
                });

                result.userMessage = String.Format("All teams obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Team_Service: GetAllTeams() method executed successfuly.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed fetch all the required teams from the database";
                result.internalMessage = String.Format("ERROR: LOGIC.Services.Implementation.Team_Service: GetAllTeams(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<Team_ResultSet>> GetTeamById(int id)
        {
            Generic_ResultSet<Team_ResultSet> result = new Generic_ResultSet<Team_ResultSet>();
            try
            {
                Team Team = await _crud.Read<Team>(id);
                Team_ResultSet teamReturend = new Team_ResultSet
                {
                    id = Team.Id,
                    name = Team.Name,
                    region = Team.Region
                };

                result.userMessage = String.Format("Team {0} was found successfully", teamReturend.name);
                result.internalMessage = "LOGIC.Services.Implementation.Team_Service: GetTeamById() method executed successfuly.";
                result.result_set = teamReturend;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed find the player you are looking for.";
                result.internalMessage = String.Format("ERROR: LOGIC.Services.Implementation.Team_Service: GetTeamById(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<Team_ResultSet>> UpdateTeam(int id, string name, Region region)
        {
            Generic_ResultSet<Team_ResultSet> result = new Generic_ResultSet<Team_ResultSet>();
            try
            {
                Team Team = new Team
                {
                    Id = id,
                    Name = name,
                    Region = region
                };

                Team = await _crud.Update<Team>(Team, id);

                Team_ResultSet teamUpdated = new Team_ResultSet
                {
                    id = Team.Id,
                    name = Team.Name,
                    region = Team.Region
                };

                result.userMessage = String.Format("The supplied team {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Team_Service: UpdateTeam() method executed successfuly.";
                result.result_set = teamUpdated;
                result.success = true;
            }
            catch(Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed to update your information for the team supplied. Please try again.";
                result.internalMessage = String.Format("ERROR: LOGIC.Implementations.Team_Service: UpdateTeam(): {0}", exception.Message);
            }
            return result;
        }
    }
}
