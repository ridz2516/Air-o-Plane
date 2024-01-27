using System;
using UnityEngine;

public abstract class PlaneState: IDisposable
{
    readonly IPlayerController _PlayerShip;

    public abstract void Update();

    public virtual void Start() {}

    public virtual void Dispose(){}

    public virtual void OnTriggerEnter(Collider other) { }
}
