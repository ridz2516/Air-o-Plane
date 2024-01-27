using System;
using UnityEngine;
using Zenject;

public class SimpleWallBg : Environment
{

    ILooper _EnvironmentLooper;
    Setting _Setting;

    [Inject]
    public void Construct(ILooper _environmentLooper, Setting _Setting)
    {
        _EnvironmentLooper = _environmentLooper;
        this._Setting = _Setting;
    }

    #region Init

    private void Start()
    {
        Activate();
    }

    #endregion Init

    private void Update()
    {
        if (_EnvironmentLooper != null)
        {
            _EnvironmentLooper.UpdateDistance(0.1f);
        }
    }

    public override void Activate()
    {

        AllChildEnvironment = GetComponentsInChildren<IEnvironmentChunk>(true);
        _EnvironmentLooper.UpdateElements(AllChildEnvironment, _Setting.MaxDistanceBetweenEnvironment);

    }


    [Serializable]
    public class Setting
    {
        public GameObject WallsObject;
        public float MaxDistanceBetweenEnvironment = 10;
    }

    public class Factory : PlaceholderFactory<SimpleWallBg> { }

}
