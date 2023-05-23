using System;
using VioletHell.InventorySystem;
using UnityEngine;

namespace InternalAssets.Scripts.Content
{
    [CreateAssetMenu]
    public class TestItem : Item
    {
        public override Type GetItemType() => typeof(TestItem);
    }
}