using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VioletHell.InventorySystem.HUD
{
    [RequireComponent(typeof(Image))]
    public sealed class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Image _slotImage;
        [SerializeField] private TMP_Text _itemsCountText;
        
        public Type ItemType
            => _currentItem?.GetType();

        private Item _currentItem;
        private int _itemsCount = 0;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonPressed);
            
            SetItem(null);
        }

        public void RemoveItems(int count)
        {
            if (count <= _itemsCount)
            {
                _itemsCount -= count;
                UpdateItemsCountText();
                
                if(_itemsCount <= 0)
                    ResetSlot();
            }
        }

        private void UpdateItemsCountText()
        {
            _itemsCountText.text = _itemsCount.ToString();
        }
        public void SetItem(Item item)
        {
            if (item == null) ResetSlot();
            else AddItem(item);

            _currentItem = item;
        }

        private void AddItem(Item item)
        {
            if (_currentItem != null && _currentItem.GetItemType() == item.GetItemType())
            {
                _itemsCount++;
                UpdateItemsCountText();
                return;
            }

            _slotImage.enabled = true;
            _slotImage.sprite = item.ItemSprite;

            _itemsCount = 1;
            
            if (item is UsableItem)
                _button.enabled = true;
                
            UpdateItemsCountText();
        }

        private void ResetSlot()
        {
            _currentItem = null;
            _slotImage.enabled = false;
            _button.enabled = false;

            _itemsCount = 0;
        }

        private void OnButtonPressed()
        {
            (_currentItem as UsableItem)?.Use();
        }
    }
}