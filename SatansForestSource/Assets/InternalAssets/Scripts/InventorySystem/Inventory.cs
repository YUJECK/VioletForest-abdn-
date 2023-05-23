using System;
using System.Collections.Generic;

namespace SatansForest.InventorySystem
{
    public sealed class Inventory : IInventory
    {
        public event Action<Item> OnItemAdded;
        public event Action<Type> OnItemRemoved;
        
        private readonly InventoryConfig _config;
        private readonly Dictionary<Type, int> _items = new();

        public int InventorySize => _config.InventorySize;
        
        public Inventory(InventoryConfig config)
        {
            _config = config;
        }

        public void Add<TItem>(TItem item) where TItem : Item
        {
            if (item != null && _items.Count <= _config.InventorySize)
            {
                if (_items.ContainsKey(typeof(TItem)))
                {
                    _items[typeof(TItem)]++;
                    return;
                }
                
                OnItemAdded?.Invoke(item);
            }
        }

        public void Remove<TItem>() where TItem : Item
        {
            if (_items.ContainsKey(typeof(TItem)))
            {
                _items.Remove(typeof(TItem));
                OnItemRemoved?.Invoke(typeof(TItem));
            }
        }

        public Item Get<TItem>() where TItem : Item
        {
            return null;
        }

        public bool Contains<TItem>() where TItem : Item
        {
            return _items.ContainsKey(typeof(TItem));
        }
    }
}