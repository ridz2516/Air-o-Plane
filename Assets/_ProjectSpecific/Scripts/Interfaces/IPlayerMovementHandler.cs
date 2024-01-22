using UnityEngine;

public interface IPlayerMovementHandler
{
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }
    public Vector3 GetForward { get; }
}
