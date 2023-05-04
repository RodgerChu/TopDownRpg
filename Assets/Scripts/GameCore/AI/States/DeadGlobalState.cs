using System;
using System.Collections.Generic;
using GameCore.AI.TransitionConditions;
using GameCore.Animations;
using GameCore.Fight.Character;
using UnityEngine;

namespace GameCore.AI.States
{
    public class DeadGlobalState: BaseCharacterGlobalState
    {
        private float m_elapsedDeadTimer;
        private float m_deadTimer;
        private Action<ICharacter> m_onDeadTimerElapsed;

        public override void OnStateEnter(ICharacter character)
        {
            character.animationController.PlayAnimation(AnimationType.Die);
            m_elapsedDeadTimer = 0f;
        }

        public override void OnStateLeave(ICharacter character)
        {
        }

        protected override void UpdateInternal(ICharacter character)
        {
            if (m_elapsedDeadTimer >= m_deadTimer)
            {
                return;
            }
            
            m_elapsedDeadTimer += Time.deltaTime;
            if (m_elapsedDeadTimer >= m_deadTimer)
            {
                m_onDeadTimerElapsed(character);
            }
        }

        public DeadGlobalState(List<StateTransitionCondition> transitions, float deadTimer, Action<ICharacter> onDeadTimerElapsed) : base(transitions)
        {
            m_deadTimer = deadTimer;
            m_onDeadTimerElapsed = onDeadTimerElapsed;
        }
    }
}