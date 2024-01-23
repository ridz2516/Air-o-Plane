
using UnityEngine;
using Zenject;

public abstract class Environment : MonoBehaviour
{
    [SerializeField] protected IEnvironmentChunk[] AllChildEnvironment;
    protected int _currentIndex;

    public abstract void Activate();

}