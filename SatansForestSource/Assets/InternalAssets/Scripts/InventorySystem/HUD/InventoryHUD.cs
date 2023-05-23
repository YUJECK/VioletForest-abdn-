using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SatansForest.InventorySystem.HUD
{
    public sealed class InventoryHUD : MonoBehaviour
    {
        [SerializeField] private List<ItemSlot> slots;

        private IInventory _inventory;

        [Inject]
        public void Construct(IInventory inventory)
        {
            _inventory = inventory;
            
            _inventory.OnItemAdded += OnItemAdded;
            _inventory.OnItemRemoved += OnItemRemoved;
        }

        private ItemSlot GetSlotWith(Type type)
        {
            foreach (var itemSlot in slots)
            {
                if (itemSlot.ItemType == type)
                    return itemSlot;
            }

            return null;
        }
        
        private void OnItemRemoved(Type itemType)
        {
            GetSlotWith(itemType)?.SetItem(null);
        }

        private void OnItemAdded(IItem item)
        {
            GetSlotWith(null)?.SetItem(item);
        }
    }
}