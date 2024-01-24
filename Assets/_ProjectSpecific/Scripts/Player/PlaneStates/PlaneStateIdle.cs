
using System;
using UnityEngine;
using Zenject;

public class PlaneStateIdle : PlaneState
{
    readonly Settings _settings;
    readonly IPlayerMovementHandler _MovementHandler;

    Vector3 _StartingPosition;
    float _theta;

    public PlaneStateIdle(Settings _settings, IPlayerMovementHandler _MovementHandler)
    {
        this._settings = _settings;
        this._MovementHandler = _MovementHandler;
    }

    public override void Start()
    {
        _MovementHandler.Position = _MovementHandler.Position + _settings.StartOffset;
        _StartingPosition = _MovementHandler.Position;

        _MovementHandler.Rotation = Quaternion.Euler(-11.05f, 90, 0);
    }
    public override void Update()
    {
        _MovementHandler.Position = _StartingPosition + Vector3.up * _settings.Amplitude * Mathf.Sin(_theta);
        _theta += Time.deltaTime * _settings.Frequency;
    }


    [Serializable]
    public class Settings
    {
        public Vector3 StartOffset;
        public float Amplitude;
        public float Frequency;
    }

    public class Factory : PlaceholderFactory<PlaneStateIdle>
    {

    }
}
