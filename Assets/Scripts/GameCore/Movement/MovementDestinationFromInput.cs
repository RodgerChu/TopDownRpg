using GameCore.Input;
using UnityEngine;
using Zenject;

namespace GameCore.Movement
{
    public class MovementDestinationFromInput: IMovementDestinationProvider
    {
        [Inject] private IMovementInput m_movementInput; 
        
        public Vector2 GetDestination()
        {
            return m_movementInput.GetInput();
        }
    }
}