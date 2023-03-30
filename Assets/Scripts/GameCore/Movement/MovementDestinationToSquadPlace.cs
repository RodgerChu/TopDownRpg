using UnityEngine;

namespace GameCore.Movement
{
    public class MovementDestinationToSquadPlace : IMovementDestinationProvider
    {
        
        
        public Vector2 GetDestination()
        {
            return Vector2.down;
        }
    }
}
