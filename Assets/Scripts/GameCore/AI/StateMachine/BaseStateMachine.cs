using System.Collections.Generic;
using GameCore.AI.States;
using GameCore.AI.TransitionConditions;
using GameCore.Animations;
using GameCore.Fight.Character;
using GameCore.Fight.Character.Stats;
using GameCore.Fight.EnemiesLocator;
using GameCore.Movement;
using Zenject;

public abstract class BaseStateMachine
{
    [Inject] protected IEnemiesLocator m_enemiesLocator;
    [Inject] protected SquadPositionsProvider m_squadPositionsProvider;
    [Inject] protected AttackModeProvider m_attackModeProvider;
    
    private ICharacterState m_currentState;

    public BaseStateMachine()
    {
        InstallStatesAndTransitions();
    }

    private void InstallStatesAndTransitions()
    {
        var idleState = new IdleGlobalState(new List<StateTransitionCondition>(5));
        var moveState = new MoveToSquadGlobalState(new List<StateTransitionCondition>(5));
        var attackState = new AttackGlobalState(new List<StateTransitionCondition>(5));

        idleState.AddTransition(new StateTransitionCondition(character =>
        {
            if (!m_enemiesLocator.HasEnemiesInSight())
            {
                return false;
            }

            if (character.animationController.lastPlayerAnimation == AnimationType.Attack)
            {
                return false;
            }
            
            var destination = m_enemiesLocator.GetNearestEnemy(character).position;
            var targetVector = destination - character.position;
            return targetVector.SqrMagnitude() < character.characterStats[CharacterStatType.AttackRange] * 
                character.characterStats[CharacterStatType.AttackRange];
        }, character =>
        {
            
        }, attackState));
        idleState.AddTransition(new StateTransitionCondition(character =>
        {
            if (m_enemiesLocator.HasEnemiesInSight())
            {
                return false;
            }
            
            var destination = m_squadPositionsProvider.GetDestination(character);
            var targetVector = destination - character.position;
            return targetVector.SqrMagnitude() > 0.5f;
        }, character =>
        {
            moveState.SetDestination(m_squadPositionsProvider);
        }, moveState));
        idleState.AddTransition(new StateTransitionCondition(character =>
        {
            if (!m_enemiesLocator.HasEnemiesInSight())
            {
                return false;
            }
            
            var destination = m_enemiesLocator.GetNearestEnemy(character).position;
            var targetVector = destination - character.position;
            return targetVector.SqrMagnitude() > character.characterStats[CharacterStatType.AttackRange] * 
                character.characterStats[CharacterStatType.AttackRange];
        }, character =>
        {
            moveState.SetDestination(m_enemiesLocator);
        }, moveState));
        
        moveState.AddTransition(new StateTransitionCondition(character =>
        {
            if (moveState.destinationPoint != m_squadPositionsProvider)
            {
                return false;
            }
            
            var destination = m_squadPositionsProvider.GetDestination(character);
            var targetVector = destination - character.position;
            return targetVector.SqrMagnitude() <= 0.5f;
        }, character =>
        {
            
        }, idleState));
        moveState.AddTransition(new StateTransitionCondition(character =>
        {
            return moveState.destinationPoint != m_enemiesLocator && 
                   m_attackModeProvider.attackMode == AttackMode.Aggressive && 
                   m_enemiesLocator.HasEnemiesInSight();
        }, character =>
        {
            moveState.SetDestination(m_enemiesLocator);
        }, moveState));
        moveState.AddTransition(new StateTransitionCondition(character =>
        {
            if (m_enemiesLocator.GetNearestEnemy(character) is null)
            {
                return false;
            }
            
            var vectorToEnemy = m_enemiesLocator.GetNearestEnemy(character).position - character.position;
            var sqrLength = vectorToEnemy.sqrMagnitude;
            var characterAttackRangeSqr = character.characterStats[CharacterStatType.AttackRange] *
                                          character.characterStats[CharacterStatType.AttackRange];
            return character.animationController.lastPlayerAnimation != AnimationType.Attack && 
                   sqrLength <= characterAttackRangeSqr;
        }, character =>
        {
            attackState.SetTarget(m_enemiesLocator.GetNearestEnemy(character));
        }, attackState));
        moveState.AddTransition(new StateTransitionCondition(character =>
        {
            return moveState.destinationPoint == m_enemiesLocator &&
                   !m_enemiesLocator.HasEnemiesInSight();
        }, character =>
        {
            moveState.SetDestination(m_squadPositionsProvider);
        }, moveState));
        attackState.AddTransition(new StateTransitionCondition(character =>
        {
            return character.animationController.lastPlayerAnimation == AnimationType.Attack;
        }, character =>
        {
            
        }, idleState));
        InstallAdditionalStates(new List<BaseCharacterGlobalState>(3)
        {
            idleState,
            moveState,
            attackState
        });

        m_currentState = idleState;
    }
    
    protected virtual void InstallAdditionalStates(List<BaseCharacterGlobalState> states) { }

    public void TransitionToState(ICharacterState state, ICharacter character)
    {
        m_currentState?.OnStateLeave(character);
        m_currentState = state;
        m_currentState.OnStateEnter(character);
    }

    public void Update(ICharacter character)
    {
        m_currentState?.OnUpdate(character);
    }
}
