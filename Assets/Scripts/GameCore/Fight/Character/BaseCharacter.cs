using GameCore.Fight.AI;
using GameCore.Fight.Character.Stats;
using GameCore.Pooling;
using UnityEngine;
using Zenject;

namespace GameCore.Fight.Character
{
    public class BaseCharacter : MonoBehaviour, ICharacter
    {
        [Inject] private Pool<BaseState> m_statesPool;

        [SerializeField]
        private CharacterController m_characterController;

        private BaseState m_currentState;

        public CharacterType characterType => CharacterType.Hero;
        CharacterController ICharacter.characterController => m_characterController;
        public CharacterStats characterStats { get; } = new()
        {
            moveSpeed = 4f
        };

        private void Awake()
        {
            m_currentState = m_statesPool.Get<IdleState>();
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
    }
}
