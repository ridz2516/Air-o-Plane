
using System;
using UnityEngine;
using Zenject;

public class LevelStartPresenter : IInitializable, IDisposable
{
    readonly Screen_LevelStart  _LevelStart;
    readonly IPlayerStatesHandler _IPlayerState;

    
    public LevelStartPresenter(Screen_LevelStart _LevelStart, IPlayerStatesHandler _IPlayerState)
    {
        this._LevelStart = _LevelStart;
        this._IPlayerState = _IPlayerState;
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
        _IPlayerState.ChangeState(ePlaneStates.TakeOff);
    }
}
