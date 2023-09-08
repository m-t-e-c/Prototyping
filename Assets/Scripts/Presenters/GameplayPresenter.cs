using FishingIdle.Models;
using FishingIdle.Presenters;
using FishingIdle.UIElements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace DefaultNamespace
{
    public class GameplayPresenter : BasePresenter<GameplayPresenter>
    {
        [SerializeField] Joystick joystick;
        [SerializeField] UIButton inventoryButton;
        [SerializeField] Slider hungerSlider;
        [SerializeField] TextMeshProUGUI hungerLevelLabel;


        GameplayModel _model;

        protected override void Start()
        {
            _model = new GameplayModel();
            _model.IsStarving?.Subscribe(OnStarvingStateChanged);
            _model.HungerLevel?.Subscribe(OnHungerLevelChanged);
            inventoryButton.onClick.AddListener(OnInventoryButtonClick);
        }

        void OnStarvingStateChanged(bool isStarving)
        {
            
        }
        
        void OnHungerLevelChanged(float hungerLevel)
        {
            hungerSlider.value = hungerLevel / 100f;
            hungerLevelLabel.text = hungerLevel.ToString("0");
        }

        void OnInventoryButtonClick()
        {
            _model.ShowInventory();
        }

        public Joystick GetJoystick()
        {
            return joystick;
        }

        void OnDestroy()
        {
            inventoryButton.onClick.RemoveListener(OnInventoryButtonClick);
        }
    }
}