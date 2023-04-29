using GameCore.AI.StateMachine;
using Zenject;

namespace GameCore.Zenject
{
    public class PlayerCharacterStatesInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BaseStateMachine>().To<PlayerStateMachine>().AsTransient();
        }
    }
}