using UnityEngine;

namespace VioletHell.InventorySystem
{
    [CreateAssetMenu]
    public sealed class InventoryConfig : ScriptableObject
    {
        [field: SerializeField] public int InventorySize { get; private set; }
    }
}