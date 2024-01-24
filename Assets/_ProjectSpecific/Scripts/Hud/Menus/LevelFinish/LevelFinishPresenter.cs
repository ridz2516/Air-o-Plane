
using System;
using UnityEngine;
using Zenject;

public class LevelFinishPresenter: IInitializable, IDisposable
{
    readonly Screen_LevelFinish _LevelFinish;
    readonly GameManager _GameManager;


    public LevelFinishPresenter(GameManager _GameManager, Screen_LevelFinish _LevelFinish)
    {
        this._GameManager = _GameManager;
        this._LevelFinish = _LevelFinish;
    }

    public void Dispose()
    {
        _LevelFinish.RestartButton.onClick.RemoveAllListeners();
    }

    public void Initialize()
    {
        _LevelFinish.RestartButton.onClick.AddListener(onClickRetry);
    }

    private void onClickRetry()
    {
        _GameManager.LevelRestart();
        _LevelFinish.Hide();
    }
}
