using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Smoke : MonoBehaviour, IPoolable<IMemoryPool>
{
    [SerializeField]
    float _lifeTime;

    [SerializeField]
    ParticleSystem _particleSystem;

    float _startTime;

    IMemoryPool _pool;

    public void Update()
    {
        if (Time.realtimeSinceStartup - _startTime > _lifeTime)
        {
            _pool.Despawn(this);
        }
    }

    public void OnDespawned()
    {
    }

    public void OnSpawned(IMemoryPool pool)
    {
        _particleSystem.Clear();
        _particleSystem.Play();

        _startTime = Time.realtimeSinceStartup;
        _pool = pool;
    }

    public class Factory : PlaceholderFactory<Smoke>
    {
    }
}
