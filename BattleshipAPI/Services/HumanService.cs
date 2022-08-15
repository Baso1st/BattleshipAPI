namespace BattleshipAPI.Services
{
    public class HumanService : PlayerService
    {
        public HumanService(string name, PlacementStrategyService placementStrategy) : base(name, placementStrategy)
        {
        }
    }
}
