using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public enum eEnvironmentType
{
    ParkBackground,
    ParkObstacles
}

public class EnvironmentManager : MonoBehaviour
{
    #region Data

    [SerializeField] private eEnvironmentType[] _EnvironmentType;

    private EnvironmentFactory _EnvironmentFactory;
    private List<Environment> _Environments = new List<Environment>();

    #endregion Data

    #region Init

    [Inject]
    public void Construct(EnvironmentFactory _EnvironmentFactory)
    {
        this._EnvironmentFactory = _EnvironmentFactory;
    }

    public void Start()
    {
        _EnvironmentFactory.CreateEnvironment(eEnvironmentType.ParkObstacles);
    }

    #endregion Init

    public void Reset()
    {
        
    }
}



