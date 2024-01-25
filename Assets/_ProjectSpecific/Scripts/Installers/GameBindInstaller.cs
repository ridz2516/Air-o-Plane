
using UnityEngine;
using Zenject;

public class GameBindInstaller : MonoInstaller
{
    [SerializeField] GameObject Object;
    public override void InstallBindings()
    {
        InstallGameManager();
        InstallPlayer();
        InstallPresenter();
        InstallEnvironment();

        GameSignalInstaller.Install(Container);
    }

    public void InstallGameManager()
    {
        Container.Bind<GameManager>().AsSingle();
    }

    public void InstallPlayer()
    {
        Container.Bind<PlaneStateFactory>().AsSingle();

        Container.BindFactory<PlaneStateIdle, PlaneStateIdle.Factory>().WhenInjectedInto<PlaneStateFactory>();
        Container.BindFactory<PlaneStateTakeOff, PlaneStateTakeOff.Factory>().WhenInjectedInto<PlaneStateFactory>();
        Container.BindFactory<PlaneStateDead, PlaneStateDead.Factory>().WhenInjectedInto<PlaneStateFactory>();
        Container.Bind(typeof(IPlayerController), typeof(IPlayerStatesHandler)).To<PlayerPlane>().FromComponentInHierarchy().AsSingle();
        Container.BindFactory<PlaneStateMoving, PlaneStateMoving.Factory>().WhenInjectedInto<PlaneStateFactory>();

        Container.BindInterfacesAndSelfTo<PlayerDistanceMeasure>().AsSingle();
    }

    public void InstallPresenter()
    {
        Container.BindInterfacesAndSelfTo<LevelStartPresenter>().AsSingle();
        Container.BindInterfacesAndSelfTo<GamePlayInputPresenter>().AsSingle();
        Container.BindInterfacesAndSelfTo<LevelFinishPresenter>().AsSingle();
    }

    public void InstallEnvironment()
    {
        Container.Bind<EnvironmentFactory>().AsSingle();
        Container.BindInterfacesAndSelfTo<EnvironmentLooper>().AsTransient();
    }
    


}
