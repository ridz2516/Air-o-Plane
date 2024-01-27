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
        Container.BindInstance(Player.PlaneStateDeadSettings);

        Container.BindFactory<Explosion, Explosion.Factory>()
                .FromPoolableMemoryPool<Explosion, ExplosionPool>(poolBinder => poolBinder
                    .WithInitialSize(2)
                    .FromComponentInNewPrefab(Player.PlayerDeathEffect)
                    .UnderTransformGroup("Explosions"));

        Container.BindFactory<Smoke, Smoke.Factory>()
                .FromPoolableMemoryPool<Smoke, SmokePool>(poolBinder => poolBinder
                    .WithInitialSize(1)
                    .FromComponentInNewPrefab(Player.SmokeEffect)
                    .UnderTransformGroup("Smoke"));

        Container.BindInstance(Input);

        Container.BindInstance(Environment.SimpleWallEnvirSettings);
        Container.BindFactory<SimpleWallEnvironment, SimpleWallEnvironment.Factory>()
               .FromComponentInNewPrefab(Environment.SimpleWallEnvirSettings.WallsObject)
               .UnderTransformGroup("Environment");

    }

    class ExplosionPool : MonoPoolableMemoryPool<IMemoryPool, Explosion>
    {
    }

    class SmokePool : MonoPoolableMemoryPool<IMemoryPool, Smoke>
    {
    }

}

[Serializable]
public class PlayerVariables
{
    public PlaneStateIdle.Settings      PlaneIdleSettings;
    public PlaneStateMoving.Settings    PlaneMovingSettings;
    public PlaneStateDead.Settings      PlaneStateDeadSettings;

    public GameObject PlayerDeathEffect;
    public GameObject SmokeEffect;
}

[Serializable]
public class InputVariables
{
    public float DragSensitivity = 1;
}

[Serializable]
public class EnvironmentConfig
{
    public SimpleWallEnvironment.Setting SimpleWallEnvirSettings;
}


