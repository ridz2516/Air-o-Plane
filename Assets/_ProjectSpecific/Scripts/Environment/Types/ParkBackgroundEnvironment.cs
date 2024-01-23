
using UnityEngine;
using Zenject;

public class ParkBackgroundEnvironment : Environment
{
    IPlayerMovementHandler _IMovementHandlerPlayer;

    //[Inject]
    //public void Construct(IPlayerMovementHandler _IMovementHandlerPlayer)
    //{
    //    this._IMovementHandlerPlayer = _IMovementHandlerPlayer;
    //}

    public override void Activate()
    {
        Debug.Log("ParkBackground Activated");
    }

    public override void DeActivate()
    {
    }

    public void Update()
    {
        
    }

    public override void LoadNext()
    {
    }

    public class Setting
    {
        public GameObject ParkBackgroundObject;
    }

    public class Factory : PlaceholderFactory<ParkBackgroundEnvironment> { }
}
