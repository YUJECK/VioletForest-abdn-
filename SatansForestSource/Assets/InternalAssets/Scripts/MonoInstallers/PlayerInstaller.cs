using SatansForest.InputServices;
using Zenject;

namespace SatansForest.MonoInstallers
{
    public sealed class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<InputSystemService>()
                .FromInstance(new InputSystemService());
        }
    }
}