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
        private struct DeathTimer
        {
            public ICharacter character;
            public float elapsedTime;
        }

        private List<DeathTimer> m_characterDeathTimers = new List<DeathTimer>(5);
        private float m_deadTimer;
        private Action<ICharacter> m_onDeadTimerElapsed;

        public override void OnStateEnter(ICharacter character)
        {
            character.animationController.PlayAnimation(AnimationType.Die);
        }

        public override void OnStateLeave(ICharacter character)
        {
        }

        protected override void UpdateInternal(ICharacter character)
        {
            var dt = Time.deltaTime;
            for (int i = 0; i < m_characterDeathTimers.Count; i++)
            {
                var timerInfo = m_characterDeathTimers[i];
                timerInfo.elapsedTime += dt;
                if (timerInfo.elapsedTime >= m_deadTimer)
                {
                    m_onDeadTimerElapsed(timerInfo.character);
                }
            }
        }

        public DeadGlobalState(List<StateTransitionCondition> transitions, float deadTimer, Action<ICharacter> onDeadTimerElapsed) : base(transitions)
        {
            m_deadTimer = deadTimer;
            m_onDeadTimerElapsed = onDeadTimerElapsed;
        }
    }
}