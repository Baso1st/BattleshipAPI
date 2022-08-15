using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipAPI.Models
{
    public enum CellState
    {
        Empty = 0,
        HasShip = 1,
        Miss = 2,
        Hit = 3
    }
}
