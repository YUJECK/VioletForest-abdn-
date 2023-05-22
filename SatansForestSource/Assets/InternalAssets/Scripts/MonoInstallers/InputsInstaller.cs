using SatansForest.InputServices;
using SatansForest.MouseSelections;
using Zenject;

namespace SatansForest.MonoInstallers
{
    public sealed class InputsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var inputService = new InputSystemService();
                
            Container
                .BindInterfacesAndSelfTo<InputSystemService>()
                .FromInstance(inputService)
                .AsSingle();
            
            Container
                .Bind<MouseSelector>()
                .FromInstance(new MouseSelector(inputService))
                .AsSingle();
        }
    }
}