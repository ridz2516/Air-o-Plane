
using System;
using UnityEngine;
using Zenject;

public class ParkObstacleEnvironment : Environment
{

    IPlayerMovementHandler _IMovementHandlerPlayer;

    [Inject]
    public void Construct(IPlayerMovementHandler _IMovementHandlerPlayer)
    {
        this._IMovementHandlerPlayer = _IMovementHandlerPlayer;
    }

    public override void Activate()
    {
        Debug.Log("ParkObstacle Activated");
    }

    public override void DeActivate()
    {
    }

    public override void LoadNext()
    {
    }

    public override void UpdateDistance(float i_LoopDistance)
    {
    }

    [Serializable]
    public class Setting
    {
        public GameObject ParkObstacleObject;
    }

    public class Factory : PlaceholderFactory<ParkObstacleEnvironment> { }

}
