using GameCore.Fight.AI;
using GameCore.Fight.EnemiesLocator;
using GameCore.Movement;
using GameCore.Pooling;
using UnityEngine;
using Zenject;

namespace GameCore.Zenject
{
    public class EnemiesContextInstaller: MonoInstaller
    {
        [SerializeField] private EnemiesLocator m_enemiesLocator;
        [SerializeField] private SquadPositionsProvider m_holdPositionProvider;

        public override void InstallBindings()
        {
            Container.Bind<IEnemiesLocator>().FromInstance(m_enemiesLocator).AsSingle();
            Container.Bind<SquadPositionsProvider>().FromInstance(m_holdPositionProvider).AsSingle();
            Container.Bind<Pool<BaseCharacterState>>().AsSingle();
            Container.Bind<AttackModeProvider>().AsSingle();
        }
    }
}