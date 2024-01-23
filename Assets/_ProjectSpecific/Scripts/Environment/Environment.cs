
using UnityEngine;
using Zenject;

public abstract class Environment : MonoBehaviour, ILooper
{
    [SerializeField] protected GameObject[] AllChildEnvironment;

    public abstract void Activate();
    public abstract void DeActivate();
    public abstract void LoadNext();

    public virtual void UpdateDistance(float loopDistance)
    {
    }
}