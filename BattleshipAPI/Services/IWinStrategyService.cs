using System.Collections.Generic;

namespace BattleshipAPI.Services
{
    public interface IWinStrategyService
    {
        public PlayerService GetWinner(IReadOnlyCollection<PlayerService> players);

    }
}