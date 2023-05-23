using VioletHell.InputServices;
using VioletHell.MouseSelections;
using Zenject;

namespace VioletHell.MonoInstallers
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
                .BindInterfacesAndSelfTo<MouseSelector>()
                .FromInstance(new MouseSelector(inputService))
                .AsSingle();
        }
    }
}