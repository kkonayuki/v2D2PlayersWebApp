using DAL.Entities.Enums;
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface ITeam_Service
    {
        Task<Generic_ResultSet<Team_ResultSet>> AddTeam(string name, Region region);
        Task<Generic_ResultSet<List<Team_ResultSet>>> GetAllTeams();
        Task<Generic_ResultSet<Team_ResultSet>> GetTeamById(int id);
        Task<Generic_ResultSet<Team_ResultSet>> UpdateTeam(int id, string name, Region region);
    }
}
