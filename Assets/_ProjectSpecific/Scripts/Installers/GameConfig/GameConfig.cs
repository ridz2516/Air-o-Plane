using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameConfig")]
public class GameConfig : ScriptableObjectInstaller<GameConfig>
{
    public PlayerVariables Player = new PlayerVariables();
    public InputVariables Input = new InputVariables();
    public EnvironmentConfig Environment = new EnvironmentConfig();

    public override void InstallBindings()
    {
        Container.BindInstance(Player.PlaneIdleSettings);
        Container.BindInstance(Player.PlaneMovingSettings);
        Container.BindInstance(Input);

        Container.BindInstance(Environment.ParkObstacleSettings);
        Container.BindFactory<ParkObstacleEnvironment, ParkObstacleEnvironment.Factory>()
               .FromComponentInNewPrefab(Environment.ParkObstacleSettings.ParkObstacleObject)
               .UnderTransformGroup("Environment");
    }

}

[Serializable]
public class PlayerVariables
{
    public PlaneStateIdle.Settings PlaneIdleSettings;
    public PlaneStateMoving.Settings PlaneMovingSettings;
}

[Serializable]
public class InputVariables
{
    public float DragSensitivity = 1;
}

[Serializable]
public class EnvironmentConfig
{
    public ParkObstacleEnvironment.Setting ParkObstacleSettings;
}


