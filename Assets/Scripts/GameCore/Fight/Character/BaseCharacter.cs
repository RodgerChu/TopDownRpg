using System.Collections.Generic;
using GameCore.AI;
using GameCore.AI.States;
using GameCore.AI.Tags;
using GameCore.Animations;
using GameCore.Fight.Character.Stats;
using Pathfinding;
using UnityEngine;
using Zenject;

namespace GameCore.Fight.Character
{
    public abstract class BaseCharacter : MonoBehaviour, ICharacter
    {
        [Inject] private BaseStateMachine m_stateMachine;

        [SerializeField] private CharacterTag m_characterTag;
        [SerializeField] private AIPath m_aiPath;
        [SerializeField] private CharacterAnimationController m_animationController;

        public CharacterAnimationController animationController => m_animationController;
        public Dictionary<CharacterStatType, float> characterStats { get; } = new Dictionary<CharacterStatType, float>
        {
            {CharacterStatType.AttackRange, 3f},
            {CharacterStatType.MoveSpeed, 5f},
            {CharacterStatType.Health, 100f},
            {CharacterStatType.Armor, 5},
            {CharacterStatType.AttackPower, 5f}
        };

        private Transform m_cachedTransform;
        
        private void Awake()
        {
            m_cachedTransform = transform;
            m_aiPath.maxSpeed = characterStats[CharacterStatType.MoveSpeed];
        }

        private void Update()
        {
            m_stateMachine.Update(this);
        }

        public void TransitionToState(BaseCharacterGlobalState state)
        {
            m_stateMachine.TransitionToState(state, this);
        }

        public void SetEnabled(bool enabled)
        {
            m_characterTag.gameObject.SetActive(enabled);
        }

        public Vector2 position => m_cachedTransform.position;
        public void MoveTo(Vector2 destination)
        {
            m_aiPath.isStopped = false;
            m_aiPath.destination = destination;
        }

        public void Stop()
        {
            m_aiPath.isStopped = true;
        }

        public void TeleportTo(Vector2 position)
        {
            m_aiPath.transform.position = position;
        }
    }
}
