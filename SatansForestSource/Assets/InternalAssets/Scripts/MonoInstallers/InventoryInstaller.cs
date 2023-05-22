using SatansForest.InventorySystem;
using UnityEngine;
using Zenject;

namespace SatansForest.MonoInstallers
{
    public sealed class InventoryInstaller : MonoInstaller
    {
        [SerializeField] private InventoryConfig _inventoryConfig;
        
        public override void InstallBindings()
        {
            var inventory = new Inventory(_inventoryConfig);

            Container
                .Bind<IInventory>()
                .FromInstance(inventory)
                .AsSingle();
        }
    }
}