using System.Collections.Generic;
using BattleshipAPI.Models;

namespace BattleshipAPI.Services
{
    public class AutoPlacementService : PlacementStrategyService
    {
        public AutoPlacementService(ICollection<ShipService> ships, int rowCount, int colCount) : base(ships, rowCount, colCount)
        {

        }
        public override Cell[,] PlaceShips()
        {
            //ToDo: Change this function to do random ship placement. 
            var board = new Cell[rowCount, colCount];

            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < colCount; c++)
                {
                    board[r, c] = new Cell();
                }
            }

            var i = 0;
            foreach (var ship in ships)
            {
                for (int j = 0; j < ship.Size; j++)
                {
                    board[i, j] = new Cell(CellState.HasShip, ship);
                }
                i++;
            }
            return board;
        }
    }
}
