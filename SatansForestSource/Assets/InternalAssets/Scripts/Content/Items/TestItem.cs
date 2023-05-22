using SatansForest.InventorySystem;
using UnityEngine;

namespace InternalAssets.Scripts.Content
{
    [CreateAssetMenu]
    public class TestItem : ScriptableObject, IItem
    {
        [field: SerializeField] public Sprite ItemSprite { get; private set; }
        [field: SerializeField] public string ItemName { get; private set; }
        [field: SerializeField] public string ItemDescription { get; private set; }
    }
}