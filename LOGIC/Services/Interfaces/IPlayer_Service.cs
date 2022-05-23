
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IPlayer_Service
    {
        Task<Generic_ResultSet<Player_ResultSet>> AddPlayer(string firstName, string lastName, string nickName, int age, int? teamId, int countryId, decimal? prizeMoney);
        Task<Generic_ResultSet<List<Player_ResultSet>>> GetAllPlayers();
        Task<Generic_ResultSet<Player_ResultSet>> GetPlayerById(int id);
        Task<Generic_ResultSet<List<Player_ResultSet>>> GetPlayersByTeamId(int id);
        Task<Generic_ResultSet<Player_ResultSet>> UpdatePlayer(int id, string firstName, string lastName, string nickName, int age, int? teamId, int countryId, decimal? prizeMoney);
    }
}
