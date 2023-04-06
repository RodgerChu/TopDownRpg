using GameCore.Fight.AI;
using GameCore.Fight.Character.Stats;
using GameCore.Pooling;
using Pathfinding;
using UnityEngine;
using Zenject;

namespace GameCore.Fight.Character
{
    public class BaseCharacter : MonoBehaviour, ICharacter
    {
        [Inject] private Pool<BaseState> m_statesPool;

        [SerializeField] private AIPath m_aiPath;
        

        private BaseState m_currentState;
        private Transform m_cachedTransform;
        
        public CharacterStats characterStats { get; } = new()
        {
            moveSpeed = 4f
        };

        private void Awake()
        {
            m_currentState = m_statesPool.Get<IdleState>();
            m_cachedTransform = transform;
        }

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
