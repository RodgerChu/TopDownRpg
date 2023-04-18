using GameCore.Fight.AI;

namespace GameCore.Fight.Character
{
    public class PlayerCharacter: BaseCharacter
    {
        protected override BaseState GetDefaultState()
        {
            return m_statesPool.Get<IdleState>();
        }
    }
}