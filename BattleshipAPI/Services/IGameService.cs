using System.Collections.Generic;
using System;

namespace BattleshipAPI.Services
{
    public interface IGameService
    {
        public int Id { get; set; }
        public PlayerService Winner { get;}

        public bool HasWinner();

        public string Fire(PlayerService offensivePlayer, PlayerService defensivePlayer, Tuple<int, int> coord);

        public PlayerService GetNextPlayer();
    }
}
