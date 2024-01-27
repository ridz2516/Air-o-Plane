
using NUnit.Framework;
using UnityEngine;
using Zenject;
using Moq;

public class EnvironmentFactoryTest : ZenjectIntegrationTestFixture
{

    [Test]
    public void CreateEnvironment_ParkObstalce_ReturnsSimpleObstacleEnvironment()
    {
        PreInstall();

        Container.Bind<EnvironmentFactory>().AsSingle();

        Container.Bind<ILooper>().To<MockLooper>().AsSingle();
        var setting = new SimpleWallEnvironment.Setting();
        Container.BindInstance(setting);

        Container.BindFactory<SimpleWallEnvironment, SimpleWallEnvironment.Factory>()
               .FromComponentInNewPrefabResource("Test/SimpleWallEnvironment");
        

        Container.Bind<IInitializable>().To<ParkRunner>().AsSingle();

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
            var environment = _Factory.CreateEnvironment(eEnvironmentType.SimpleWallEnvo);
            environment.Activate();

            Assert.IsNotNull(environment);
            Assert.IsTrue(environment is SimpleWallEnvironment);
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
            var environment = _Factory.CreateEnvironment(eEnvironmentType.SimpleWallBG);
            environment.Activate();

            Assert.IsNotNull(environment);
            Assert.IsTrue(environment is SimpleWallBg);
        }
    }

}

