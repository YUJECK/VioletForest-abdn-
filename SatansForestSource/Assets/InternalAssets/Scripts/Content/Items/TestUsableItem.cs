using SatansForest.InventorySystem;
using UnityEngine;

namespace InternalAssets.Scripts.Content
{
    [CreateAssetMenu]
    public class TestUsableItem : UsableItem
    {
        public override void Use()
        {
            Debug.Log("sd;lfk");    
        }
    }
}