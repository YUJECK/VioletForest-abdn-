using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SatansForest.InventorySystem.HUD
{
    public sealed class InventoryHUD : MonoBehaviour
    {
        [SerializeField] private GameObject slotPrefab;
        
        private IInventory _inventory;
        [SerializeField] private List<ItemSlot> _slots;

        [Inject]
        public void Construct(IInventory inventory)
        {
            _inventory = inventory;
            
            _inventory.OnItemAdded += OnItemAdded;
            _inventory.OnItemRemoved += OnItemRemoved;
        }

        private void Awake()
        {
            CreateSlots();
        }

        private void CreateSlots()
        {
            
        }

        private ItemSlot GetSlotWith(Type type)
        {
            foreach (var itemSlot in _slots)
            {
                if (itemSlot.ItemType() == type)
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