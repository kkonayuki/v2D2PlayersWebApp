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
    public class Player_Service : IPlayer_Service
    {
        private ICRUD _crud = new CRUD();
        public async Task<Generic_ResultSet<Player_ResultSet>> AddPlayer(string firstName, string lastName, string nickName, int age, int? teamId, int countryId, decimal? prizeMoney)
        {
            Generic_ResultSet<Player_ResultSet> result = new Generic_ResultSet<Player_ResultSet>();
            try
            {
                Player Player = new Player
                {
                    FirstName = firstName,
                    LastName = lastName,
                    NickName = nickName,
                    Age = age,
                    PrizeMoney = prizeMoney,
                    TeamId = teamId,
                    CountryId = countryId

                };

                Player = await _crud.Create<Player>(Player);

                Player_ResultSet playedAdded = new Player_ResultSet
                {
                    id = Player.Id,
                    firstName = Player.FirstName,
                    lastName = Player.LastName,
                    nickName = Player.NickName,
                    age = Player.Age,
                    prizeMoney = Player.PrizeMoney,
                    teamId = Player.TeamId,
                    countryId = Player.CountryId
                };

                result.userMessage = String.Format("The supplied Player {0} was added successfully", nickName);
                result.internalMessage = "LOGIC.Services.Implementation.Player_Service: AddPlayer() method executed successfuly.";
                result.result_set = playedAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed to register your information for the player supplied. Please try again.";
                result.internalMessage = String.Format("ERROR: LOGIC.Services.Implementation.Player_Service: AddPlayer(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Player_ResultSet>>> GetAllPlayers()
        {
            Generic_ResultSet<List<Player_ResultSet>> result = new Generic_ResultSet<List<Player_ResultSet>>();
            try
            {
                List<Player> Players = await _crud.ReadAll<Player>();

                result.result_set = new List<Player_ResultSet>();

                Players.ForEach(pg => {
                    result.result_set.Add(new Player_ResultSet
                    {
                        id = pg.Id,
                        firstName = pg.FirstName,
                        lastName = pg.LastName,
                        nickName = pg.NickName,
                        age = pg.Age,
                        prizeMoney = pg.PrizeMoney,
                        teamId = pg.TeamId,
                        countryId = pg.CountryId
                    });
                });

                result.userMessage = String.Format("All players obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Player_Service: GetAllPlayers() method executed successfuly.";
                result.success = true;
            }
            catch(Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed fetch all the required players from the database";
                result.internalMessage = String.Format("ERROR: LOGIC.Services.Implementation.Player_Service: GetAllPlayers(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<Player_ResultSet>> GetPlayerById(int id)
        {
            Generic_ResultSet<Player_ResultSet> result = new Generic_ResultSet<Player_ResultSet>();
            try
            {
                Player Player = await _crud.Read<Player>(id);

                Player_ResultSet playerReturned = new Player_ResultSet
                {
                    id = Player.Id,
                    firstName = Player.FirstName,
                    lastName = Player.LastName,
                    nickName = Player.NickName,
                    age = Player.Age,
                    prizeMoney = Player.PrizeMoney,
                    teamId = Player.TeamId,
                    countryId = Player.CountryId
                };

                result.userMessage = String.Format("Player {0} was found successfully", playerReturned.nickName);
                result.internalMessage = "LOGIC.Services.Implementation.Player_Service: GetPlayerById() method executed successfuly.";
                result.result_set = playerReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed find the player you are looking for.";
                result.internalMessage = String.Format("ERROR: LOGIC.Services.Implementation.Team_Service: GetPlayerById(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<Player_ResultSet>> UpdatePlayer(int id, string firstName, string lastName, string nickName, int age, int? teamId, int countryId, decimal? prizeMoney)
        {
            Generic_ResultSet<Player_ResultSet> result = new Generic_ResultSet<Player_ResultSet>();
            try
            {
                Player Player = new Player
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    NickName = nickName,
                    Age = age,
                    PrizeMoney = prizeMoney,
                    TeamId = teamId,
                    CountryId = countryId

                };

                Player = await _crud.Update<Player>(Player, id);

                Player_ResultSet playerUpdated = new Player_ResultSet
                {
                    id = Player.Id,
                    firstName = Player.FirstName,
                    lastName = Player.LastName,
                    nickName = Player.NickName,
                    age = Player.Age,
                    prizeMoney = Player.PrizeMoney,
                    teamId = Player.TeamId,
                    countryId = Player.CountryId
                };

                result.userMessage = String.Format("The supplied player {0} was updated successfully", firstName);
                result.internalMessage = "LOGIC.Services.Implementation.Player_Service: UpdatePlayer() method executed successfuly.";
                result.result_set = playerUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "We failed to update your information for the player supplied. Please try again.";
                result.internalMessage = String.Format("ERROR: LOGIC.Implementations.Player_Service: UpdatePlayer(): {0}", exception.Message);
            }
            return result;
        }
    }
}
