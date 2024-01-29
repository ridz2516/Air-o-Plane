using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class ObstacleMoving : ObstacleBase
{
    #region Data

    private Obstacle    _Obstacle;
    readonly Settings   _Settings;


    private float       _CurrentDelay;
    private bool        _IsActivated;
    private int         _CurrentPlatformNo;
    private float        _LastTime;

    #endregion Data

    #region Constructor

    public ObstacleMoving(Settings _Settings)
    {
        this._Settings = _Settings;
    }

    #endregion Constructor

    public override void Start()
    {
        _CurrentPlatformNo = 0;
        _Obstacle.Position = _Obstacle.GetMovementPoints[_CurrentPlatformNo].position;

    }

    public override void Update()
    {
        _CurrentDelay += Time.deltaTime;
        _CurrentDelay = Mathf.Min(_Settings.MoveDelay, _CurrentDelay);

        if(_CurrentDelay == _Settings.MoveDelay)
        {
            var direction = _Obstacle.GetMovementPoints[_CurrentPlatformNo % _Obstacle.GetMovementPoints.Length].position  - _Obstacle.Position;

            _Obstacle.MainPlatform.Translate(direction.normalized
                * _Settings.MoveSpeed * _Settings.MoveAnimCurve.Evaluate(Time.time - _LastTime) * Time.deltaTime, Space.World);

            var distance = Vector3.Distance(_Obstacle.Position, _Obstacle.GetMovementPoints[_CurrentPlatformNo % _Obstacle.GetMovementPoints.Length].position);

            if(distance <= 0.1f)
            {
                movementComplete();
            }
        }
        else
        {
            _LastTime = Time.time;
        }
    }

    private void movementComplete()
    {
        _CurrentPlatformNo++;
        _CurrentDelay = 0;
    }

    public override void Activate()
    {
        _IsActivated = true;
    }

    public override void Deactivate()
    {
        _IsActivated = false;
    }

    public override void SetObstacle(Obstacle _Obstacle)
    {
        this._Obstacle = _Obstacle;
    }


    [Serializable]
    public class Settings
    {
        public float MoveSpeed;
        public float MoveDelay;
        public AnimationCurve MoveAnimCurve;
    }

    public class Factory : PlaceholderFactory<ObstacleMoving>
    {

    }

}
