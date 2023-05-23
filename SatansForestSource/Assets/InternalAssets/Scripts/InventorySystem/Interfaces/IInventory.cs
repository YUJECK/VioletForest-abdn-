using System;

namespace VioletHell.InventorySystem
{
    public interface IInventory
    {
        event Action<Item, int> OnItemAdded;
        event Action<Type> OnItemRemoved;

        int InventorySize { get; }

        public void Add(Item item);
        public void Remove(Type type);
        public Item Get<TItem>() where TItem : Item;
        public bool Contains<TItem>() where TItem : Item;
    }
}