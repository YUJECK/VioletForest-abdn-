using System;
using System.Collections.Generic;

namespace VioletHell.InventorySystem
{
    public sealed class Inventory : IInventory
    {
        public event Action<Item, int> OnItemAdded;
        public event Action<Type> OnItemRemoved;
        public event Action<Type[]> OnInventoryUpdated;
        
        private readonly InventoryConfig _config;
        private readonly Dictionary<Type, int> _items = new();

        public int InventorySize => _config.InventorySize;
        
        public Inventory(InventoryConfig config)
        {
            _config = config;
        }

        public void Add(Item item)
        {
            if (item != null && _items.Count <= _config.InventorySize)
            {
                if (_items.ContainsKey(item.GetItemType()))
                {
                    _items[item.GetItemType()]++;
                }
                else
                {
                    _items.Add(item.GetItemType(), 1);
                }

                OnItemAdded?.Invoke(item, _items[item.GetItemType()]);
            }
        }

        public void Remove(Type itemType)
        {
            if (_items.ContainsKey(itemType))
            {
                _items[itemType]--;
                
                if (_items[itemType] == 0)
                    _items.Remove(itemType);
                
                OnItemRemoved?.Invoke(itemType);
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