using System.Collections.Generic;

namespace FishingIdle.Managers.Interfaces
{

    public interface IItemManager
    {
        public ItemDataOutput GetItem(string itemID);
        public ItemDataOutput GetCookedItem(ItemDataOutput itemData);
        public List<ItemDataOutput> GetItems();
        
    }
}