using System.Collections.Generic;
using GameCore.Animations;
using GameCore.Fight.AI;
using GameCore.Fight.Character.Stats;
using GameCore.Pooling;
using Pathfinding;
using UnityEngine;
using Zenject;

namespace GameCore.Fight.Character
{
    public abstract class BaseCharacter : MonoBehaviour, ICharacter
    {
        [Inject] protected Pool<BaseState> m_statesPool;

        [SerializeField] private AIPath m_aiPath;
        [SerializeField] private CharacterAnimationController m_animationController;

        public CharacterAnimationController animationController => m_animationController;
        public Dictionary<CharacterStatType, float> characterStats { get; } = new Dictionary<CharacterStatType, float>
        {
            { CharacterStatType.AttackRange, 1f},
            { CharacterStatType.MoveSpeed, 0.5f}
        };

        private BaseState m_currentState;
        private Transform m_cachedTransform;
        private void Awake()
        {
            m_currentState = GetDefaultState();
            m_cachedTransform = transform;
        }

        protected abstract BaseState GetDefaultState();

        private void Update()
        {
            m_currentState.OnUpdate(this);
        }

        public void TransitionToState(BaseState state)
        {
            if (m_currentState != null)
            {
                m_currentState.OnStateLeave(this);
                m_statesPool.Return(m_currentState);
            }

            m_currentState = state;
            m_currentState.OnStateEnter(this);
        }

        public Vector2 position => m_cachedTransform.position;
        public void MoveTo(Vector2 destination)
        {
            m_aiPath.destination = destination;
        }
    }
}
