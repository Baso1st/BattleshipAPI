namespace BattleshipAPI.Models
{
    public class HitEffect
    {
        public bool IsHit { get; set; }
        public string HitReport { get; set; }
        public HitEffect(bool isHit, string hitReport)
        {
            IsHit = isHit;
            HitReport = hitReport;
        }

    }
}