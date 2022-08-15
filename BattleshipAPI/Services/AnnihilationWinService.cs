using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleshipAPI.Services
{
    public class AnnihilationWinService : IWinStrategyService
    {
        public PlayerService GetWinner(IReadOnlyCollection<PlayerService> players)
        {
            if (players != null && players.Count == 1)
            {
                return players.FirstOrDefault();
            }
            return null;
        }
    }
}
