using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSignalInstaller : Installer<GameSignalInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<GameManager.OnLevelStarted>();
        Container.DeclareSignal<GameManager.OnLevelCompleted>();
        Container.DeclareSignal<GameManager.OnLevelRestart>();

        Container.BindSignal<GameManager.OnLevelCompleted>().ToMethod<Screen_LevelFinish>(x => x.Show).FromResolve();
        Container.BindSignal<GameManager.OnLevelRestart>().ToMethod<Screen_LevelStart>(x => x.Show).FromResolve();
    }
}
