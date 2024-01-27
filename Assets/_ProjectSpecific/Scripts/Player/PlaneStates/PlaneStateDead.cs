using System;
using UnityEngine;
using Zenject;

public class PlaneStateDead : PlaneState
{
    readonly IPlayerController  _IPlayerController;
    readonly Settings           _Settings;
    readonly Explosion.Factory  _explosionFactory;
    readonly GameManager        _GameManager;
    readonly AudioPlayer        _AudioPlayer;

    private float _JumpStartTime;
    private float _StartYPos;
    private Smoke _Smoke;
    

    public PlaneStateDead(IPlayerController _IPlayerController,
        Settings _Settings,
        Explosion.Factory _explosionFactory,
        GameManager _GameManager,
        AudioPlayer _AudioPlayer)
    {
        this._IPlayerController = _IPlayerController;
        this._Settings = _Settings;
        this._explosionFactory = _explosionFactory;
        this._GameManager = _GameManager;
        this._AudioPlayer = _AudioPlayer;
    }

    public override void Start()
    {
        _IPlayerController.SetAnimation(eAnimation.Dead);
        _JumpStartTime = Time.time;
        _StartYPos = _IPlayerController.Position.y;

        explode();
        _GameManager.LevelFinished();
    }

    public override void Update()
    {

        float elapsedTime = Time.time - _JumpStartTime;
        float normalizedTime = Mathf.Clamp01(elapsedTime / _Settings.JumpDuration);
        float yPosition = _Settings.FallDownAnimCurve.Evaluate(normalizedTime) * _Settings.JumpHeight;

        _IPlayerController.Position = new Vector3(_IPlayerController.Position.x, _StartYPos + yPosition, _IPlayerController.Position.z);

        
    }

    private void explode()
    {
        var explosion = _explosionFactory.Create();
        explosion.transform.position = _IPlayerController.Position;

        _IPlayerController.TrailRenderer.emitting = false;
        _AudioPlayer.Play(_Settings.DeathSFXClip, _Settings.SfxDeathVolume);
    }

    [Serializable]
    public class Settings
    {
        public AnimationCurve FallDownAnimCurve;
        public float JumpHeight = 5f;
        public float JumpDuration = 1f;
        public AudioClip DeathSFXClip;
        public float SfxDeathVolume = 3;
    }

    public class Factory : PlaceholderFactory<PlaneStateDead>
    {

    }
}
