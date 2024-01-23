
using NUnit.Framework;
using UnityEngine;
using Zenject;

public class EnvironmentFactoryTest : ZenjectIntegrationTestFixture
{

    GameObject _parkBackgroundPrefab
    {
        get { return Resources.Load<GameObject>("Test/ParkBackgroundEnvironment"); }
    }


    [Test]
    public void CreateEnvironment_ParkBackground_ReturnsParkBackgroundEnvironment()
    {
        PreInstall();

        Container.Bind<EnvironmentFactory>().AsSingle();
        Container.BindFactory<ParkObstacleEnvironment, ParkObstacleEnvironment.Factory>()
               .FromComponentInNewPrefabResource("Test/ParkBackgroundEnvironment");
        Container.Bind<IInitializable>().To<ParkRunner>().AsSingle();

        PostInstall();
    }

    public class ParkRunner : IInitializable
    {
        readonly EnvironmentFactory _Factory;

        public ParkRunner(
            EnvironmentFactory Factory)
        {
            _Factory = Factory;
            Debug.Log("Injected");
        }

        public void Initialize()
        {
            Debug.Log("Init");
            var environment = _Factory.CreateEnvironment(eEnvironmentType.ParkObstacles);
            Debug.Log("Fetch");
            environment.Activate();

            Assert.IsNotNull(environment);
            Assert.IsTrue(environment is ParkObstacleEnvironment);
        }
    }

}

