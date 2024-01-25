using Zenject;
using UnityEngine;

public class PlayerDistanceMeasure: IInitializable, ITickable
{
    #region Data

    readonly IPlayerController  _PlayerController;
    readonly SignalBus          _SignalBus;

    private Vector3 _StartPosition, _EndPosition;
    private bool _CanDetectDistance;


    #endregion Data

    public PlayerDistanceMeasure(IPlayerController _PlayerController, SignalBus _SignalBus)
    {
        this._PlayerController = _PlayerController;
        this._SignalBus = _SignalBus;
    }

    public void Initialize()
    {
        _SignalBus.Subscribe<GameManager.OnLevelStarted>(onLevelStarted);
        _SignalBus.Subscribe<GameManager.OnLevelCompleted>(onLeveFinished);
    }

    public void Tick()
    {
        if (_CanDetectDistance)
        {
            _EndPosition = _PlayerController.Position;
        }
    }

    public int DistanceCovered
    {
        get => (int)Vector3.Distance(_StartPosition, _EndPosition);
    }

    #region Event

    private void onLevelStarted()
    {
        _CanDetectDistance = true;
        _StartPosition = _PlayerController.Position;
    }

    private void onLeveFinished()
    {
        _CanDetectDistance = false;
    }

    #endregion Event
}
