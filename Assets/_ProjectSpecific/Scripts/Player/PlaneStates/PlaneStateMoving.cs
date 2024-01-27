using System;
using UnityEngine;
using Zenject;

public class PlaneStateMoving : PlaneState, IMovementControl
{
    #region Data

    readonly Settings               _settings;
    readonly IPlayerController      _PlayerMovementHandler;
    readonly GamePlayInputPresenter _GameInputPresenter;
    readonly IPlayerStatesHandler   _PlayStatesHandler;
    

    float _CurrentRotation;
    float _UpperLimit;
    float _LowerLimit;

    #endregion Data

    #region Constructor

    public PlaneStateMoving(Settings _settings,
        IPlayerController _PlayerMovementHandler,
        GamePlayInputPresenter _GameInputPresenter,
        IPlayerStatesHandler _PlayStatesHandler)
    {
        this._settings = _settings;
        this._PlayerMovementHandler = _PlayerMovementHandler;
        this._GameInputPresenter = _GameInputPresenter;
        this._PlayStatesHandler = _PlayStatesHandler;
    }

    #endregion Constructor

    #region Init

    public override void Start()
    {
        _PlayerMovementHandler.TrailRenderer.emitting = true;
    }


    #endregion Init

    #region Unity Loop

    public override void Update()
    {
        Move();
        if (_GameInputPresenter.IsInputDown)
        {
            Rotate(_GameInputPresenter.DeltaDrag);
        }else
        {
            ResetRotation();
        }
        _PlayerMovementHandler.Rotation = Quaternion.Euler(-_CurrentRotation, 90, 0);

    }

    #endregion Unity Loop

    #region Physics

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(nameof(eTags.Environment)))
        {
            _PlayStatesHandler.ChangeState(ePlaneStates.Dead);
        }
    }

    #endregion Physics

    public void Move()
    {
        var pos = _PlayerMovementHandler.Position + _PlayerMovementHandler.GetForward * _settings._ForwardSpeed * Time.deltaTime;
        float distance = pos.z - Camera.main.transform.position.z;

        _UpperLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance)).y - _settings._MaxHeightOffset;
        _LowerLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).y + _settings._MaxHeightOffset;

        pos.y = Mathf.Clamp(pos.y, _LowerLimit, _UpperLimit);

        _PlayerMovementHandler.Position = pos;
    }

    public void Rotate(Vector2 i_Rotate)
    {
        float rotationAmount = i_Rotate.y * _settings._RotationSpeed * Time.deltaTime;
        _CurrentRotation = Mathf.Clamp(_CurrentRotation + rotationAmount, -_settings._AngleLimit, _settings._AngleLimit);

    }

    public void ResetRotation()
    {

        _CurrentRotation = Mathf.Lerp(_CurrentRotation, 0, 2 * Time.deltaTime);
        //_theta += Time.deltaTime * _settings.IdleFrequency;
    }

    public bool IsInputDown { get; set; }

    [Serializable]
    public class Settings
    {
        public float _ForwardSpeed;
        public float _RotationSpeed;
        public float _AngleLimit;
        public float _MaxHeightOffset;

    }

    public class Factory : PlaceholderFactory<PlaneStateMoving>
    {

    }
}
