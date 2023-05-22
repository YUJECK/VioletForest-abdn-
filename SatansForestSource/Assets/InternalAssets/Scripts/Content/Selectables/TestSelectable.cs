using InternalAssets.Scripts.Content;
using SatansForest.InventorySystem;
using SatansForest.MouseSelections;
using UnityEngine;
using Zenject;

namespace SatansForest.Scripts.Content.Selectables
{
    public sealed class TestSelectable : MonoBehaviour, IMouseSelectable
    {
        [SerializeField] private TestItem item;
        private IInventory _inventory;

        [Inject]
        private void Construct(IInventory inventory)
        {
            _inventory = inventory;
        }
        
        public void Select()
        {
            _inventory.Add(item);            
        }

        public void OnMousePointed() { }
        public void OnMouseDepointed() { }
    }
}