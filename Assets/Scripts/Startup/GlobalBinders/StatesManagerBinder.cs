using States;
using Zenject;

namespace Startup.GlobalBinders
{
    public class StatesManagerBinder : MonoInstaller
    {
        public override void InstallBindings()
        {
            var inst = Container.Instantiate<StatesManager>();
            Container.Bind<StatesManager>()
                .FromInstance(inst)
                .AsSingle();
        }
    }
}