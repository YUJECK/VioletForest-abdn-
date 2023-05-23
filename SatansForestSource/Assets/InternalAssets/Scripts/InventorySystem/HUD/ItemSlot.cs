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

        private IItem _currentItem;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonPressed);
            
            SetItem(null);
        }


        public void SetItem(IItem item)
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
                
                if(item is IUsableItem)
                    _button.enabled = true;
            }

            _currentItem = item;
        }

        private void OnButtonPressed()
        {
            (_currentItem as IUsableItem)?.Use();
        }
    }
}