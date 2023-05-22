using UnityEngine;

namespace SatansForest.InventorySystem
{
    public interface IItem
    {
        Sprite ItemSprite { get; }
        string ItemName{ get; }
        string ItemDescription{ get; }
    }
}