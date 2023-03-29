using UnityEngine;

namespace GameCore.Movement
{
    public interface IMovementDestinationProvider
    {
        Vector2 GetDestination();
    }
}
