using InternalAssets.Scripts.Content;
using UnityEngine;
using VioletHell.InventorySystem;
using VioletHell.MouseSelections;
using Zenject;

namespace VioletHell.Content.Selectables
{
    public sealed class TestSelectable : MonoBehaviour, IMouseSelectable
    {
        [SerializeField] private Item item;
        
        private IInventory _inventory;
        private SpriteRenderer _sprite;
        private DiContainer _container;

        [Inject]
        private void Construct(IInventory inventory, DiContainer container)
        {
            _inventory = inventory;
            _container = container;

            item = Instantiate(item);
            _container.Inject(item);
            
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