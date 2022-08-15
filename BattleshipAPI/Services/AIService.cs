namespace BattleshipAPI.Services
{
    internal class AIService : PlayerService
    {
        public AIService(string name, PlacementStrategyService placementStrategy) : base(name, placementStrategy)
        {
        }
    }
}
