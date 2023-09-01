using System;
using FishingIdle.Managers.Interfaces;

namespace FishingIdle.Models
{
    public class FishingZoneModel : IDisposable
    {
        readonly FishingZoneDataOutput _fishingZoneDataOutput;
        readonly IFishingZoneManager _fishingZoneManager;

        public FishingZoneModel(string zoneID)
        {
            _fishingZoneManager = Locator.Instance.Resolve<IFishingZoneManager>();
            _fishingZoneDataOutput = _fishingZoneManager.GetFishingZone(zoneID);
        }
        
        public FishingZoneDataOutput GetFishingZoneData()
        {
            return _fishingZoneDataOutput;
        }
        
        public void StartFishing()
        {
            
        }
        
        public void Dispose()
        {
        }
    }
}