using UnityEngine;

public interface IMovementControl
{
    public void Move();
    public void Rotate(Vector2 i_Rotate);
    public bool IsInputDown { get; set; }
    public void ResetRotation();
}
