using System;
using UnityEngine;
using UnityEngine.UI;

namespace SatansForest.InventorySystem.HUD
{
    [RequireComponent(typeof(Image))]
    public sealed class ItemSlot : MonoBehaviour
    {
        public IItem CurrentItem { get; private set; }
        [SerializeField] private Image _slotImage;

        private void Awake()
        {
//            _slotImage = GetComponentInChildren<Image>();
            SetItem(null);
        }

        public Type ItemType()
        {
            if (CurrentItem == null)
                return null;
            else
            {
                return CurrentItem.GetType();
            }
        }
        public void SetItem(IItem item)
        {
            if (item == null)
            {
                _slotImage.enabled = false;
            }
            else
            {
                _slotImage.enabled = true;
                _slotImage.sprite = item.ItemSprite;
            }

            CurrentItem = item;
        }
    }
}