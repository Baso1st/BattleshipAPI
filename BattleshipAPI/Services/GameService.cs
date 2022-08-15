using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;


namespace BattleshipAPI.Services
{
    public class GameService: IGameService
    {

        private IWinStrategyService _winStrategy;
        private Queue<PlayerService> _players;

        private static int global_id = 0;

        public int Id { get; set; }
        public PlayerService Winner { get; private set; }


        public GameService(ICollection<PlayerService> players, IWinStrategyService winStrategy)
        {
            Id = global_id;
            global_id++;
            _players = new Queue<PlayerService>(players);
            _winStrategy = winStrategy;
            foreach (var player in _players)
            {
                player.PlaceShips();
            }
        }

        public bool HasWinner()
        {
            Winner = _winStrategy.GetWinner(_players);
            return Winner != null;
        }

        public string Fire(PlayerService offensivePlayer, PlayerService defensivePlayer, Tuple<int, int> coord)
        {
            var hitEffect = defensivePlayer.TakeHit(coord);
            if (hitEffect.IsHit)
            {
                offensivePlayer.Score += 1;
                if (!defensivePlayer.HasShip())
                {
                    _players = new Queue<PlayerService>(_players.Where(x => x != defensivePlayer));
                }
            }
            return hitEffect.HitReport;
        }

        public PlayerService GetNextPlayer()
        {
            var player = _players.Dequeue();
            _players.Enqueue(player);
            return player;
        }

    }
}
