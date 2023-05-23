using System;
using UnityEngine;
using UnityEngine.UI;

namespace SatansForest.InventorySystem.HUD
{
    [RequireComponent(typeof(Image))]
    public sealed class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Image _slotImage;
        public Type ItemType
            => _currentItem?.GetType();

        private Item _currentItem;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonPressed);
            
            SetItem(null);
        }


        public void SetItem(Item item)
        {
            if (item == null)
            {
                _slotImage.enabled = false;
                _button.enabled = false;
            }
            else
            {
                _slotImage.enabled = true;
                _slotImage.sprite = item.ItemSprite;
                
                if(item is UsableItem)
                    _button.enabled = true;
            }

            _currentItem = item;
        }

        private void OnButtonPressed()
        {
            (_currentItem as UsableItem)?.Use();
        }
    }
}