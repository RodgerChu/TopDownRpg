using GameCore.Fight.AI;

namespace GameCore.Fight.Character
{
    public class PlayerCharacter: BaseCharacter
    {
        protected override BaseCharacterGlobalState GetDefaultState()
        {
            return m_statesPool.Get<IdleGlobalState>();
        }
    }
}