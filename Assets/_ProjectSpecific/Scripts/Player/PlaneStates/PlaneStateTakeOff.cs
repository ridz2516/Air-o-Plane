using System;
using UnityEngine;
using Zenject;

public class PlaneStateTakeOff : PlaneState
{
    #region Data

    readonly Settings _settings;
    readonly IPlayerController _PlayerMovementHandler;
    readonly IPlayerStatesHandler _PlayerStatesHandler;
    readonly GamePlayInputPresenter _GameInputPresenter;

    float _CurrentRotation;
    float _CurrentSpeed;

    #endregion Data

    #region Constructor

    public PlaneStateTakeOff(Settings _settings, IPlayerController _PlayerMovementHandler, IPlayerStatesHandler _PlayerStatesHandler, GamePlayInputPresenter _GameInputPresenter)
    {
        this._settings = _settings;
        this._PlayerMovementHandler = _PlayerMovementHandler;
        this._PlayerStatesHandler = _PlayerStatesHandler;
        this._GameInputPresenter = _GameInputPresenter;
    }

    #endregion Constructor

    #region Init


    #endregion Init

    #region Unity Loop

    public override void Update()
    {
        Move();
        
    }

    #endregion Unity Loop

    public void Move()
    {
        if (_GameInputPresenter.IsInputDown)
        {
            _CurrentSpeed = Mathf.Lerp(_CurrentSpeed, _settings.ForwardMaxSpeed, _settings.ForwardIncreaseSpeed * Time.deltaTime);

            if (_CurrentSpeed >= (_settings.ForwardMaxSpeed / 2))
                _CurrentRotation = 0;
            else
                _CurrentRotation = -11.05f;

                _PlayerMovementHandler.Rotation = Quaternion.Lerp(_PlayerMovementHandler.Rotation, Quaternion.Euler(_CurrentRotation, 90, 0), _settings.RotationResetSpeed * Time.deltaTime);

        }
        else
        {
            _CurrentSpeed = Mathf.Lerp(_CurrentSpeed, 0, _settings.ForwardIncreaseSpeed * Time.deltaTime);
        }

        _PlayerMovementHandler.Position += Vector3.right * _CurrentSpeed * Time.deltaTime;

        if (_CurrentSpeed >= (_settings.ForwardMaxSpeed - 0.1f))
        {
            _PlayerStatesHandler.ChangeState(ePlaneStates.Moving);
        }
    }


    [Serializable]
    public class Settings
    {
        public float ForwardIncreaseSpeed;
        public float ForwardMaxSpeed;

        public float MaxDistanceToChangeState = 2;
        public float RotationResetSpeed = 2;
    }

    public class Factory : PlaceholderFactory<PlaneStateTakeOff>
    {

    }
}
