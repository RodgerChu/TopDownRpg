using System.Collections.Generic;
using GameCore.AI.States;
using GameCore.AI.TransitionConditions;
using GameCore.Fight.Character.Stats;

namespace GameCore.AI.StateMachine
{
    public class EnemyStateMachine: BaseStateMachine
    {
        protected override void InstallAdditionalStates(List<BaseCharacterGlobalState> states)
        {
            var deadState = new DeadGlobalState(new List<StateTransitionCondition>(0), 3f, character =>
            {

            });
            var transitionToDeadState = new StateTransitionCondition(character =>
            {
                return character.characterStats[CharacterStatType.Health] <= 0;
            }, character =>
            {
                character.SetEnabled(false);
            }, deadState);

            foreach (var state in states)
            {
                state.AddTransition(transitionToDeadState);
            }
        }
    }
}