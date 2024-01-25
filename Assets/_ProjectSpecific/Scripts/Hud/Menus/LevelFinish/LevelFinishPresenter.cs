
using System;
using UnityEngine;
using Zenject;

public class LevelFinishPresenter: IInitializable, IDisposable
{
    readonly Screen_LevelFinish _LevelFinish;
    readonly GameManager _GameManager;
    readonly PlayerDistanceMeasure _PlayerDistanceMeasure;
    readonly SignalBus _SignalBus;


    public LevelFinishPresenter(GameManager _GameManager,
        Screen_LevelFinish _LevelFinish,
        PlayerDistanceMeasure _PlayerDistanceMeasure,
        SignalBus _SignalBus)
    {
        this._GameManager = _GameManager;
        this._LevelFinish = _LevelFinish;
        this._PlayerDistanceMeasure = _PlayerDistanceMeasure;
        this._SignalBus = _SignalBus;
    }

    public void Dispose()
    {
        _LevelFinish.RestartButton.onClick.RemoveAllListeners();
    }

    public void Initialize()
    {
        _LevelFinish.RestartButton.onClick.AddListener(onClickRetry);
        _SignalBus.Subscribe<GameManager.OnLevelCompleted>(onLevelFinished);
    }

    private void onClickRetry()
    {
        _GameManager.LevelRestart();
        _LevelFinish.Hide();
    }

    private void onLevelFinished()
    {
        _LevelFinish.DistanceText.text = _PlayerDistanceMeasure.DistanceCovered + "m";
    }

}
