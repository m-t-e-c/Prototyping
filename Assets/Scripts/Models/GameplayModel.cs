using FishingIdle.Managers.Interfaces;
using FishingIdle.Presenters;

namespace FishingIdle.Models
{
    public class GameplayModel
    {
        IViewManager _viewManager;

        public GameplayModel()
        {
            _viewManager = Locator.Instance.Resolve<IViewManager>();
        }

        public void ShowInventory()
        {
            _viewManager.LoadView(new LoadViewParams<InventoryPresenter>()
            {
                viewName = "InventoryView"
            });
        }
    }
}