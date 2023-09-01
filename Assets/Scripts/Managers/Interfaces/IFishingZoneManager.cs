using System.Collections.Generic;

namespace FishingIdle.Managers.Interfaces
{
    public interface IFishingZoneManager
    {
        public void GetConfig();
        public List<FishingZoneDataOutput> GetFishingZones();
        public FishingZoneDataOutput GetFishingZone(string zoneId);
    }
}