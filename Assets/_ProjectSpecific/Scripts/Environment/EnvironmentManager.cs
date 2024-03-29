using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public enum eEnvironmentType
{
    SimpleWallEnvo,
    SimpleWallBG
}

public class EnvironmentManager : MonoBehaviour
{
    #region Data

    [SerializeField] private eEnvironmentType[] _EnvironmentType;

    private SignalBus _SignalBus;
    private EnvironmentFactory _EnvironmentFactory;
    private List<Environment> _Environments = new List<Environment>();

    #endregion Data

    #region Init

    [Inject]
    public void Construct(EnvironmentFactory _EnvironmentFactory, SignalBus _SignalBus)
    {
        this._EnvironmentFactory = _EnvironmentFactory;
        this._SignalBus = _SignalBus;
    }

    public void Start()
    {
        _SignalBus.Subscribe<GameManager.OnLevelRestart>(OnLevelReset);
        _SignalBus.Subscribe<GameManager.OnLevelStarted>(OnLevelStart);

        foreach (var item in _EnvironmentType)
        {
            _Environments.Add(_EnvironmentFactory.CreateEnvironment(item));
        }
    }

    #endregion Init

    private void OnLevelReset()
    {
        Reset();
    }

    private void OnLevelStart()
    {
    }


    public void Reset()
    {
        foreach (var item in _Environments)
        {
            if(item)
                Destroy(item.gameObject);
        }

        foreach (var item in _EnvironmentType)
        {
            _Environments.Add(_EnvironmentFactory.CreateEnvironment(item));
        }
    }
}



