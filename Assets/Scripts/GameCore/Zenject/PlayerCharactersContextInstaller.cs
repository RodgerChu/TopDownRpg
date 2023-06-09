using GameCore.AI;
using GameCore.AI.States;
using GameCore.Fight.EnemiesLocator;
using GameCore.Movement;
using UnityEngine;
using Zenject;

namespace GameCore.Zenject
{
    public class PlayerCharactersContextInstaller : MonoInstaller
    {
        [SerializeField] private SquadPositionsProvider m_squadPositionsProvider;
        [SerializeField] private EnemiesLocator m_enemiesLocator;

        public override void InstallBindings()
        {
            Container.Bind<AttackModeProvider>().AsSingle();
            Container.Bind<SquadPositionsProvider>().FromInstance(m_squadPositionsProvider).AsSingle();
            Container.Bind<IEnemiesLocator>().FromInstance(m_enemiesLocator).AsSingle();
        }
    }
}
