using System.Collections.Generic;
using FishingIdle.Managers.Interfaces;
using UnityEngine;

namespace FishingIdle.Managers
{
    public class FishingZoneManager : IFishingZoneManager
    {
        List<FishingZoneDataOutput> _fishingZones = new();

        public FishingZoneManager()
        {
            GetConfig();
        }
        
        public void GetConfig()
        {
            _fishingZones = Services.Services.GetFishingZoneDataOutputList();
        }

        public List<FishingZoneDataOutput> GetFishingZones()
        {
            if (ReferenceEquals(_fishingZones, null) || _fishingZones.Count == 0)
            {
                Debug.Log("FishingZoneManager.GetFishingZones() - _fishingZones is null or empty.");
                return null;
            }
            return _fishingZones;
        }

        public FishingZoneDataOutput GetFishingZone(string zoneId)
        {
            foreach (var fishingZone in _fishingZones)
            {
                if (fishingZone.ID.Equals(zoneId))
                {
                    return fishingZone;
                }
            }

            Debug.Log("FishingZoneManager.GetFishingZone() - fishingZone not found.");
            return null;
        }
    }
}