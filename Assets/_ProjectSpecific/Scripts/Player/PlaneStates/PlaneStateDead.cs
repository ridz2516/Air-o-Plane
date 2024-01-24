using System;
using UnityEngine;
using Zenject;

public class PlaneStateDead : PlaneState
{
    readonly IPlayerController  _IPlayerController;
    readonly Settings           _Settings;
    readonly Explosion.Factory  _explosionFactory;
    readonly Smoke.Factory      _SmokeFactory;

    private float _JumpStartTime;
    private float _StartYPos;
    private Smoke _Smoke;
    

    public PlaneStateDead(IPlayerController _IPlayerController,
        Settings _Settings,
        Explosion.Factory _explosionFactory,
        Smoke.Factory _SmokeFactory)
    {
        this._IPlayerController = _IPlayerController;
        this._Settings = _Settings;
        this._explosionFactory = _explosionFactory;
        this._SmokeFactory = _SmokeFactory;
    }

    public override void Start()
    {
        _IPlayerController.SetAnimation(eAnimation.Dead);
        _JumpStartTime = Time.time;
        _StartYPos = _IPlayerController.Position.y;

        explode();
    }

    public override void Update()
    {

        float elapsedTime = Time.time - _JumpStartTime;
        float normalizedTime = Mathf.Clamp01(elapsedTime / _Settings.JumpDuration);
        float yPosition = _Settings.FallDownAnimCurve.Evaluate(normalizedTime) * _Settings.JumpHeight;

        _IPlayerController.Position = new Vector3(_IPlayerController.Position.x, _StartYPos + yPosition, _IPlayerController.Position.z);

        _Smoke.transform.position = _IPlayerController.Position;
    }

    private void explode()
    {
        var explosion = _explosionFactory.Create();
        explosion.transform.position = _IPlayerController.Position;

        _Smoke = _SmokeFactory.Create();
        _IPlayerController.TrailRenderer.emitting = false;
    }

    [Serializable]
    public class Settings
    {
        public AnimationCurve FallDownAnimCurve;
        public float JumpHeight = 5f;
        public float JumpDuration = 1f;
    }

    public class Factory : PlaceholderFactory<PlaneStateDead>
    {

    }
}
