using UnityEngine;

namespace GameCore.Input
{
    public class KeyboardMovementInput: IMovementInput
    {
        public Vector2 GetInput()
        {
            var input = Vector2.zero;
            if (UnityEngine.Input.GetKey(KeyCode.W))
            {
                input.y = 1;
            }
            else if (UnityEngine.Input.GetKey(KeyCode.S))
            {
                input.y = -1;
            }
            if (UnityEngine.Input.GetKey(KeyCode.A))
            {
                input.x = -1;
            }
            else if (UnityEngine.Input.GetKey(KeyCode.D))
            {
                input.x = 1;
            }

            return input;
        }
    }
}