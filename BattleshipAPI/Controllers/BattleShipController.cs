using BattleshipAPI.Models;
using BattleshipAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BattleshipAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattleShipController : ControllerBase
    {
        IActiveGamesService _activeGamesService;
        //IGameService _gameService;
        public BattleShipController(IActiveGamesService activeGamesService)
        {
            _activeGamesService = activeGamesService;
        }

        [HttpGet("{playerName}")]
        public Dictionary<string,Cell> CreateNewGame(string playerName)
        {
            var rowCount = 10;
            var colCount = 10;

            var computer = new AIService("Computer", new AutoPlacementService(GetShips("Computer"), rowCount, colCount));
            var human = new HumanService(playerName, new AutoPlacementService(GetShips(playerName), rowCount, colCount));
            var players = new List<PlayerService>()
            {
                computer,
                human
            };
            var winStrategy = new AnnihilationWinService();
            var game = new GameService(players, winStrategy);
            var dict = new Dictionary<string, Cell>();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    dict.Add($"{i},{j}", human.Board[i, j]);
                }
            }
            return dict;
        }

        private ICollection<ShipService> GetShips(string name)
        {
            var ships = new List<ShipService>();
            ships.Add(new AirCraftCarrier(name + " Thunder"));
            ships.Add(new Destroyer(name + " Navy Pride"));
            ships.Add(new Destroyer(name + " Navigator"));
            ships.Add(new Submarine(name + " Silent Hunter"));
            ships.Add(new Submarine(name + " Whisperer"));
            ships.Add(new Submarine(name + " Sea snake"));
            ships.Add(new SmallBoat(name + " boat1"));
            ships.Add(new SmallBoat(name + " boat2"));
            ships.Add(new SmallBoat(name + " boat3"));
            ships.Add(new SmallBoat(name + " boat4"));
            return ships;
        }

        // POST api/<BattleShipController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BattleShipController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BattleShipController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
