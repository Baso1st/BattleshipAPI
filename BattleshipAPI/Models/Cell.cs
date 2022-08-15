
using BattleshipAPI.Services;

namespace BattleshipAPI.Models
{
    public class Cell
    {
        public CellState State { get; set; }
        public ShipService Ship { get; set; }

        public Cell(CellState state = CellState.Empty, ShipService ship = null)
        {
            State = state;
            Ship = ship;
        }
    }
}