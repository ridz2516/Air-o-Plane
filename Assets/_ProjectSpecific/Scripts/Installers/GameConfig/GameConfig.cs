using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameConfig")]
public class GameConfig : ScriptableObjectInstaller<GameConfig>
{
    public PlayerVariables Player = new PlayerVariables();
    public InputVariables Input = new InputVariables();

    public override void InstallBindings()
    {
        Container.BindInstance(Player.PlaneIdleSettings);
        Container.BindInstance(Player.PlaneMovingSettings);
        Container.BindInstance(Input);
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


