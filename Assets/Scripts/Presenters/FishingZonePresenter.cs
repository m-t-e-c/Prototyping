using FishingIdle.Models;
using FishingIdle.UIElements;
using TMPro;
using UnityEngine;

namespace FishingIdle.Presenters
{
    public class FishingZonePresenter : BasePresenter<FishingZonePresenter>
    {
        [SerializeField] UIButton startFishingButton;
        [SerializeField] TextMeshProUGUI startFishingButtonLabel;

        FishingZoneModel _model;

        public void Init(string zoneID)
        {
            _model = new FishingZoneModel(zoneID);
            
            _model.OnFishingStarted += OnFishingStarted;
            _model.OnFishingEnded += OnFishingEnded;
            
            startFishingButton.onClick.AddListener(OnStartFishingButtonClicked);
        }

        void OnFishingStarted()
        {
            container.gameObject.SetActive(false);
        }

        void OnFishingEnded()
        {
            container.gameObject.SetActive(true);
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