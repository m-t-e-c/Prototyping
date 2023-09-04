using FishingIdle.Models;
using FishingIdle.Presenters;
using FishingIdle.UIElements;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameplayPresenter : BasePresenter<GameplayPresenter>
    {
        [SerializeField] Joystick joystick;
        [SerializeField] UIButton inventoryButton;
        
        GameplayModel _model;

        void Start()
        {
            _model = new GameplayModel();
            inventoryButton.onClick.AddListener(OnInventoryButtonClick);
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