using System;
using GameCore.AI.States;
using GameCore.Fight.Character;

namespace GameCore.AI.TransitionConditions
{
    public sealed class StateTransitionCondition: ITransitionCondition
    {
        public BaseCharacterGlobalState targetState { get; }

        private Func<ICharacter, bool> m_condition;
        private Action<ICharacter> m_prepareToTransition;

        public StateTransitionCondition(Func<ICharacter, bool> condition, Action<ICharacter> prepareToTransition, BaseCharacterGlobalState state)
        {
            m_condition = condition;
            targetState = state;
            m_prepareToTransition = prepareToTransition;
        }
        
        public bool Check(ICharacter character)
        {
            return m_condition(character);
        }

        public void PrepareToTransition(ICharacter character)
        {
            m_prepareToTransition(character);
        }
    }
}