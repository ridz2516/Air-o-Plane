
using UnityEngine;

public abstract class ObstacleBase
{
    public abstract void Activate();
    public abstract void Deactivate();

    public virtual void Start() { }
    public virtual void Update() { }

    public virtual void OnTriggerEnter(Collider _Collide) { }
    public virtual void OnTriggerExit(Collider _Collider) { }

    public abstract void SetObstacle(Obstacle _Obstacle);
}
