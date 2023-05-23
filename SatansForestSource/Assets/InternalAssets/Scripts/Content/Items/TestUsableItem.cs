using System;
using VioletHell.InventorySystem;
using UnityEngine;
using Zenject;

namespace VioletHell.Content
{
    [CreateAssetMenu]
    public class TestUsableItem : UsableItem
    {
        private IInventory _inventory;

        [Inject]
        private void Construct(IInventory inventory)
        {
            _inventory = inventory;
        }
        
        public override void Use()
        {
            _inventory.Remove(this.GetItemType());    
        }
        
        public override Type GetItemType() => typeof(TestUsableItem);
    }
}