using Assets.Codebase.Infrastructure.InputService;
using Zenject;

namespace Assets.Codebase.Infrastructure.Installers
{
    public class InputSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<KeyboardInput>().AsSingle().NonLazy();
        }
    }
}