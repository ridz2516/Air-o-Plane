
using UnityEngine;
using Zenject;

public interface IEnvironmentFactory
{
    Environment CreateEnvironment(eEnvironmentType environmentType);
}

public class EnvironmentFactory : IEnvironmentFactory
{
    
    readonly ParkObstacleEnvironment.Factory _ParkObstacleFactory;
    readonly ParkBackgroundEnvironment.Factory _ParkBackgroundFactory;

    public EnvironmentFactory(ParkObstacleEnvironment.Factory _ParkObstacleFactory)//, ParkBackgroundEnvironment.Factory _ParkBackgroundFactory)
    {
        this._ParkObstacleFactory = _ParkObstacleFactory;
       // this._ParkBackgroundFactory = _ParkBackgroundFactory;
    }

    public Environment CreateEnvironment(eEnvironmentType environmentType)
    {
        switch (environmentType)
        {
            case eEnvironmentType.ParkObstacles:
                return _ParkObstacleFactory.Create();
        }
        return null;
    }
}

