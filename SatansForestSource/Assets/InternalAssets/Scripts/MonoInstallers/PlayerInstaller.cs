using InternalAssets.Scripts.InputServices;
using Zenject;

namespace InternalAssets.Scripts.MonoInstallers
{
    public sealed class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<NewInputSystemService>().FromInstance(new NewInputSystemService());
                
        }
    }
}