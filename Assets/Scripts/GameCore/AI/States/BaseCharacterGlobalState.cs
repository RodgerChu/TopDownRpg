using System.Collections.Generic;
using GameCore.AI.TransitionConditions;
using GameCore.Fight.Character;

namespace GameCore.AI.States
{
    public abstract class BaseCharacterGlobalState : ICharacterState
    {
        private List<StateTransitionCondition> m_transitions;

        public BaseCharacterGlobalState(List<StateTransitionCondition> transitions)
        {
            m_transitions = transitions;
        }

        public void AddTransition(StateTransitionCondition transitions)
        {
            m_transitions.Add(transitions);
        }

        public void RemoveTransition(StateTransitionCondition transition)
        {
            m_transitions.Remove(transition);
        }

        public abstract void OnStateEnter(ICharacter character);

        public void OnUpdate(ICharacter character)
        {
            if (m_transitions != null && m_transitions.Count != 0)
            {
                foreach (var transition in m_transitions)
                {
                    if (transition.Check(character))
                    {
                        transition.PrepareToTransition(character);
                        character.TransitionToState(transition.targetState);
                        return;
                    }
                }
            }
            
            UpdateInternal(character);
        }

        public abstract void OnStateLeave(ICharacter character);

        protected abstract void UpdateInternal(ICharacter character);
    }
}
