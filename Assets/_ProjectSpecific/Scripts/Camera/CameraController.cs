
using UnityEngine;
using Zenject;

public class CameraController : IInitializable
{
    readonly CameraMain _CameraMain;
    readonly SignalBus  _SignalBus;

    public CameraController (CameraMain _CameraMain, SignalBus _SignalBus)
    {
        this._CameraMain    = _CameraMain;
        this._SignalBus     = _SignalBus;
    }


    public void Initialize()
    {
        _SignalBus.Subscribe<GameManager.OnLevelRestart>(OnLevelReset);
        _SignalBus.Subscribe<GameManager.OnLevelCompleted>(OnLevelFinish);
    }

    private void OnLevelReset()
    {
        _CameraMain.GameplayVirtualCam.enabled = true;
    }

    private void OnLevelFinish()
    {
        _CameraMain.GameplayVirtualCam.enabled = false;
    }
}
