using UnityEngine;

namespace Bipolar.Input
{
    public interface IMoveInputProvider
    {
        Vector2 GetMovement();
    }

    public class MoveInputProvider : Serialized<IMoveInputProvider>, IMoveInputProvider
    {
        public Vector2 GetMovement() => Value.GetMovement();
    }
}
