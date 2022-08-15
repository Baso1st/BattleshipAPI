using System.Collections.Generic;
using BattleshipAPI.Models;

namespace BattleshipAPI.Services
{
    public abstract class PlacementStrategyService
    {
        protected ICollection<ShipService> ships;
        protected int rowCount;
        protected int colCount;
        protected PlacementStrategyService(ICollection<ShipService> ships, int rowCount, int colCount)
        {
            this.ships = ships;
            this.rowCount = rowCount;
            this.colCount = colCount;
        }

        public abstract Cell[,] PlaceShips();
    }
}