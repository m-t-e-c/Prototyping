using FishingIdle;
using FishingIdle.Extensions;
using FishingIdle.Models;
using FishingIdle.Presenters;
using FishingIdle.UIElements;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Presenters.Campfire
{
    public class CampfirePresenter : BasePresenter<CampfirePresenter>
    {
        [SerializeField] CampfireItemsScrollPanel campfireItemsScrollPanel;

        [SerializeField] UIButton collectCookedFoodButton;
        [SerializeField] Slider cookingProgressSlider;

        [SerializeField] Image rawFoodIcon;
        [SerializeField] Image cookedFoodIcon;

        CampfireModel _model;

        protected override void Start()
        {
            base.Start();
            _model = new CampfireModel();
            _model.CookingTime.Subscribe(OnCookingTimeUpdated);
            _model.OnCookingFinished += OnCookingFinished;
            
            collectCookedFoodButton.onClick.AddListener(() =>
            {
                _model.CollectCookedFood();
                rawFoodIcon.gameObject.SetActive(false);
                cookingProgressSlider.gameObject.SetActive(false);
                cookedFoodIcon.gameObject.SetActive(false);
                collectCookedFoodButton.gameObject.SetActive(false);
            });
            
            campfireItemsScrollPanel.SetData(_model.GetItems(), OnCookItemClicked);
        }

        void OnCookingTimeUpdated(float cookingTime)
        {
            cookingProgressSlider.value = cookingTime;
        }

        async void OnCookingFinished(object sender, ItemDataOutput model)
        {
            collectCookedFoodButton.gameObject.SetActive(true);
            rawFoodIcon.gameObject.SetActive(false);
            cookingProgressSlider.gameObject.SetActive(false);
            cookedFoodIcon.gameObject.SetActive(true);
            cookedFoodIcon.sprite = await AddressableExtensions.GetCookedFoodIcon(model.ID);
        }

        void OnCookItemClicked(ItemDataOutput cookItem)
        {
            _model.CookItem(cookItem, () => { OnCookingStarted(cookItem); }, null);
        }

        async void OnCookingStarted(ItemDataOutput cookItem)
        {
            collectCookedFoodButton.gameObject.SetActive(false);
            rawFoodIcon.gameObject.SetActive(true);
            rawFoodIcon.sprite = await AddressableExtensions.GetItemIcon(cookItem.ID);
            cookingProgressSlider.gameObject.SetActive(true);
            campfireItemsScrollPanel.RemoveItem(cookItem);
        }

        void OnDestroy()
        {
            _model.Dispose();
        }
    }
}