using BattleshipAPI.Models;
using System;
using System.Collections.Generic;

namespace BattleshipAPI.Services
{
    public abstract class PlayerService
    {
        protected PlacementStrategyService _placementStrategy;
        //protected Cell[,] _board;
        public Cell[,] Board { get; set; }
        public string Name { get; private set; }
        public int Score { get; set; }
        public int Hits { get; private set; }

        public PlayerService(string name, PlacementStrategyService placementStrategy)
        {
            Name = name;
            _placementStrategy = placementStrategy;
        }

        public void PlaceShips()
        {
            Board = _placementStrategy.PlaceShips();
        }

        public bool HasShip()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] != null && Board[i, j].State == CellState.HasShip)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public HitEffect TakeHit(Tuple<int, int> coord)
        {
            var (r, c) = coord;
            var cell = Board[r, c];
            if (cell.State == CellState.HasShip)
            {
                var ship = cell.Ship;
                var hitReport = ship.TakeHit();
                Hits++;
                cell.State = CellState.Hit;
                return new HitEffect(true, hitReport);
            }
            else
            {
                cell.State = CellState.Miss;
                return new HitEffect(false, "Missed!!!");
            }

        }

        public ICollection<Tuple<int, int>> GetUnhitCells()
        {
            var unhitCells = new List<Tuple<int, int>>();

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j].State == CellState.Empty || Board[i, j].State == CellState.HasShip)
                    {
                        unhitCells.Add(new Tuple<int, int>(i, j));
                    }
                }
            }
            return unhitCells;
        }
    }
}