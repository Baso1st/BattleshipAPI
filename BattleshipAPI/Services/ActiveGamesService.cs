using System.Collections.Generic;

namespace BattleshipAPI.Services
{
    public class ActiveGamesService: IActiveGamesService
    {
        public IEnumerable<GameService> games { get; set; }

    }
}
