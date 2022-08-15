using System.Collections.Generic;
using BattleshipAPI.Models;

namespace BattleshipAPI.Services
{
    internal class ManualPlacementService : PlacementStrategyService
    {
        public ManualPlacementService(ICollection<ShipService> ships, int rowCount, int colCount) : base(ships, rowCount, colCount)
        {
        }

        public override Cell[,] PlaceShips()
        {
            throw new System.NotImplementedException();
        }
    }
}
