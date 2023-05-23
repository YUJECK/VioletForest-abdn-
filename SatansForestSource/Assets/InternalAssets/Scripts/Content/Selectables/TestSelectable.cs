using InternalAssets.Scripts.Content;
using SatansForest.InventorySystem;
using SatansForest.MouseSelections;
using UnityEngine;
using Zenject;

namespace SatansForest.Content.Selectables
{
    public sealed class TestSelectable : MonoBehaviour, IMouseSelectable
    {
        [SerializeField] private Item item;
        private IInventory _inventory;
        private SpriteRenderer _sprite;

        [Inject]
        private void Construct(IInventory inventory)
        {
            _inventory = inventory;
            _sprite = GetComponent<SpriteRenderer>();
        }

        public void OnPointed()
        {
            _sprite.color = Color.white;
        }

        public void Select()
        {
            _inventory.Add(item);            
            Destroy(gameObject);
        }

        public void Deselect()
        {
            _sprite.color = Color.gray;
        }
    }
}