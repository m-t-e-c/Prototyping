using FishingIdle.Models;
using FishingIdle.UIElements;
using UnityEngine;

namespace FishingIdle.Presenters
{
    public class FishingZonePresenter : BasePresenter<FishingZonePresenter>
    {
        [SerializeField] UIButton startFishingButton;

        FishingZoneModel _model;

        public void Init(string zoneID)
        {
            _model = new FishingZoneModel(zoneID);
            startFishingButton.onClick.AddListener(OnStartFishingButtonClicked);
        }

        void OnStartFishingButtonClicked()
        {
            _model.StartFishing();
        }

        void OnDestroy()
        {
            _model.Dispose();
        }
    }
}