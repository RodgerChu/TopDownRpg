using GameCore.States;
using States;
using Zenject;

namespace Startup.GlobalBinders
{
    public class StatesManagerBinder : MonoInstaller
    {
        public override void InstallBindings()
        {
            var inst = Container.Instantiate<GameStateSystem>();
            Container.Bind<GameStateSystem>()
                .FromInstance(inst)
                .AsSingle();
        }
    }
}