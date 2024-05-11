using UnityEngine;

public class KeyboardInputProvider : IInputProvider
{
    private const string VectorHorizontal = "Horizontal";
    private const string VectorVertical = "Vertical";

    public Vector2 MoveDirection =>
        new(Input.GetAxisRaw(VectorHorizontal), Input.GetAxisRaw(VectorVertical));
}
