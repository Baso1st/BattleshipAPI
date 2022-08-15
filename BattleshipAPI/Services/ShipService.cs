namespace BattleshipAPI.Services
{
    public abstract class ShipService
    {
        private string _name;
        public int Size { get; private set; }

        public ShipService(string name, int size)
        {
            _name = name;
            Size = size;
        }

        public override string ToString()
        {
            return $"{GetType().Name} {_name}";
        }

        public string TakeHit()
        {
            Size--;
            return GetHitReport();
        }

        private string GetHitReport()
        {
            if (Size > 0)
            {
                return $"{ToString()} is critically hit. Remaining health: {Size}";
            }
            else
            {
                return $"{ToString()} has been destroyed";
            }
        }
    }


    public class AirCraftCarrier : ShipService
    {
        public AirCraftCarrier(string name) : base(name, 5)
        {
        }
    }

    public class Destroyer : ShipService
    {
        public Destroyer(string name) : base(name, 3)
        {
        }
    }
    public class Submarine : ShipService
    {
        public Submarine(string name) : base(name, 2)
        {
        }
    }
    public class SmallBoat : ShipService
    {
        public SmallBoat(string name) : base(name, 1)
        {
        }
    }
}
