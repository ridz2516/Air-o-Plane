
using NUnit.Framework;
using UnityEngine;
using Zenject;
using Moq;

public class EnvironmentFactoryTest : ZenjectIntegrationTestFixture
{

    [Test]
    public void CreateEnvironment_ParkObstalce_ReturnsParkObstacleEnvironment()
    {
        PreInstall();

        Container.Bind<EnvironmentFactory>().AsSingle();

        Container.Bind<ILooper>().To<MockLooper>().AsSingle();
        var setting = new ParkObstacleEnvironment.Setting();
        Container.BindInstance(setting);

        Container.BindFactory<ParkObstacleEnvironment, ParkObstacleEnvironment.Factory>()
               .FromComponentInNewPrefabResource("Test/ParkObstacleEnvironment");
        

        Container.Bind<IInitializable>().To<ParkRunner>().AsSingle();

        PostInstall();
    }

    [Test]
    public void CreateEnvironment_ParkBackGround_ReturnsParkBackGroundEnvironment()
    {
        PreInstall();

        Container.Bind<EnvironmentFactory>().AsSingle();
        Container.Bind<ILooper>().To<MockLooper>().AsSingle();
        var setting = new ParkBackgroundEnvironment.Setting();
        Container.BindInstance(setting);

        Container.BindFactory<ParkBackgroundEnvironment, ParkBackgroundEnvironment.Factory>()
               .FromComponentInNewPrefabResource("Test/ParkBackGround");
        Container.BindFactory<ParkObstacleEnvironment, ParkObstacleEnvironment.Factory>()
              .FromComponentInNewPrefabResource("Test/ParkObstacleEnvironment");
        Container.Bind<IInitializable>().To<ParkRunner2>().AsSingle();

        PostInstall();
    }

    public class MockLooper : ILooper
    {
        public void UpdateDistance(float loopDistance)
        {
        }

        public void UpdateElements(IEnvironmentChunk[] _newElements, float _distance)
        {
        }
    }

    public class ParkRunner : IInitializable
    {
        readonly EnvironmentFactory _Factory;

        public ParkRunner(
            EnvironmentFactory Factory)
        {
            _Factory = Factory;
        }

        public void Initialize()
        {
            var environment = _Factory.CreateEnvironment(eEnvironmentType.ParkObstacles);
            environment.Activate();

            Assert.IsNotNull(environment);
            Assert.IsTrue(environment is ParkObstacleEnvironment);
        }
    }

    public class ParkRunner2 : IInitializable
    {
        readonly EnvironmentFactory _Factory;

        public ParkRunner2(
            EnvironmentFactory Factory)
        {
            _Factory = Factory;
        }

        public void Initialize()
        {
            var environment = _Factory.CreateEnvironment(eEnvironmentType.ParkBackground);
            environment.Activate();

            Assert.IsNotNull(environment);
            Assert.IsTrue(environment is ParkBackgroundEnvironment);
        }
    }

}

