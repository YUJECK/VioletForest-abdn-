using System;

namespace SatansForest.InventorySystem
{
    public interface IInventory
    {
        event Action<IItem> OnItemAdded;
        event Action<Type> OnItemRemoved;

        int InventorySize { get; }

        public void Add<TItem>(TItem item) where TItem : IItem;
        public void Remove<TItem>() where TItem : IItem;
        public IItem Get<TItem>() where TItem : IItem;
        public bool Contains<TItem>() where TItem : IItem;
    }
}