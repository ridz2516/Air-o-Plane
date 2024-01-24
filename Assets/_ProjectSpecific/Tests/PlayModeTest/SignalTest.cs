
using NUnit.Framework;
using Zenject;

public class SignalTest: ZenjectIntegrationTestFixture
{
    // A Test behaves as an ordinary method
    [Test]
    public void Signal_OnPlayerDead()
    {
        PreInstall();

        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<OnPlayerDiedSignal>();
        Container.BindSignal<OnPlayerDiedSignal>().ToMethod<OnPlayerDiedSignalObserver>(x => x.OnPlayerDied).FromNew();

        PostInstall();
    }

    public struct OnPlayerDiedSignal
    {
    }

    public class OnPlayerDiedSignalObserver
    {
        public void OnPlayerDied()
        {
            Assert.IsTrue(true);
        }
    }

}
