using System;

namespace SatansForest.InventorySystem
{
    public interface IInventory
    {
        event Action<Item> OnItemAdded;
        event Action<Type> OnItemRemoved;

        int InventorySize { get; }

        public void Add<TItem>(TItem item) where TItem : Item;
        public void Remove<TItem>() where TItem : Item;
        public Item Get<TItem>() where TItem : Item;
        public bool Contains<TItem>() where TItem : Item;
    }
}