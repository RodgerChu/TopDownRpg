using GameCore.Input;
using Zenject;

namespace GameCore.Zenject
{
    public class PlayerMovementInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMovementInput>().FromInstance(new KeyboardMovementInput()).AsSingle().NonLazy();
        }
    }
}
