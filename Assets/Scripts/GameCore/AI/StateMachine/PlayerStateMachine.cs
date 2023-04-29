using System.Collections.Generic;
using GameCore.AI.States;
using GameCore.AI.TransitionConditions;
using GameCore.Fight.Character.Stats;

namespace GameCore.AI.StateMachine
{
    public class PlayerStateMachine: BaseStateMachine
    {
        protected override void InstallAdditionalStates(List<BaseCharacterGlobalState> states)
        {
            IdleGlobalState idleState = null;
            foreach (var state in states)
            {
                if (state is IdleGlobalState idleGlobalState)
                {
                    idleState = idleGlobalState;
                    break;
                }
            }
            
            var deadState = new DeadGlobalState(new List<StateTransitionCondition>(0), 5f, character =>
            {
                var squadPosition = m_squadPositionsProvider.GetDestination(character);
                character.TeleportTo(squadPosition);
                character.TransitionToState(idleState);
            });
            var transitionToDeathState = new StateTransitionCondition(character =>
            {
                return character.characterStats[CharacterStatType.Health] <= 0;
            }, character =>
            {
                character.SetEnabled(false);
            }, deadState);

            foreach (var state in states)
            {
                state.AddTransition(transitionToDeathState);
            }
        }
    }
}