using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameBindInstaller : MonoInstaller
{
    [SerializeField] GameObject Object;
    public override void InstallBindings()
    {
        InstallPlayer();
        InstallPresenter();
        InstallEnvironment();
    }

    public void InstallPlayer()
    {
        Container.Bind<PlaneStateFactory>().AsSingle();

        Container.BindFactory<PlaneStateIdle, PlaneStateIdle.Factory>().WhenInjectedInto<PlaneStateFactory>();
        Container.BindFactory<PlaneStateTakeOff, PlaneStateTakeOff.Factory>().WhenInjectedInto<PlaneStateFactory>();

        Container.Bind(typeof(IPlayerMovementHandler), typeof(IPlayerStatesHandler)).To<PlayerPlane>().FromComponentInHierarchy().AsSingle();
        Container.BindFactory<PlaneStateMoving, PlaneStateMoving.Factory>().WhenInjectedInto<PlaneStateFactory>();
    }

    public void InstallPresenter()
    {
        Container.BindInterfacesAndSelfTo<LevelStartPresenter>().AsSingle();
        Container.BindInterfacesAndSelfTo<GamePlayInputPresenter>().AsSingle();
        
    }

    public void InstallEnvironment()
    {
        Container.Bind<EnvironmentFactory>().AsSingle();
        Container.BindInterfacesAndSelfTo<EnvironmentLooper>().AsTransient();
    }
    


}
