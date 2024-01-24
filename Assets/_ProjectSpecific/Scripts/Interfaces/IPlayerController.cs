using UnityEngine;

public interface IPlayerController
{
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }
    public Vector3 GetForward { get; }
    public Vector3 LocalEular { get; set; }
    public void SetAnimation(eAnimation _animation);
}

