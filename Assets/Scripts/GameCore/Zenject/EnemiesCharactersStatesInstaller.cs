using GameCore.AI.StateMachine;
using Zenject;

namespace GameCore.Zenject
{
    public class EnemiesCharactersStatesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BaseStateMachine>().To<EnemyStateMachine>().AsTransient();
        }
    }
}