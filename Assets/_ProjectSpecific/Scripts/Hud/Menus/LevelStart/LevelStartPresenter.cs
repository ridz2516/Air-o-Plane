
using System;
using UnityEngine;
using Zenject;

public class LevelStartPresenter : IInitializable, IDisposable
{
    readonly GameManager _GameManager;
    readonly Screen_LevelStart  _LevelStart;

    
    public LevelStartPresenter(Screen_LevelStart _LevelStart, GameManager _GameManager)
    {
        this._LevelStart = _LevelStart;
        this._GameManager = _GameManager;
    }

    public void Dispose()
    {
        _LevelStart.PlayButton.onClick.RemoveAllListeners();
    }

    public void Initialize()
    {
        _LevelStart.PlayButton.onClick.AddListener(onPlayButtonClick);
    }

    private void onPlayButtonClick()
    {
        _LevelStart.Hide();
        _GameManager.LevelStarted();
    }
}
