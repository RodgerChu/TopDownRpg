using GameCore.Pooling;
using States.Abstraction;
using Zenject;

namespace Startup.GlobalBinders
{
    public class GlobalPoolsBinder : MonoInstaller
    {
        public override void InstallBindings()
        {
            var inst = Container.Instantiate<Pool<BaseState>>();
            Container.Bind<Pool<BaseState>>().FromInstance(inst).AsSingle();
        }
    }
}
