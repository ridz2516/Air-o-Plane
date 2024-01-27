
using UnityEngine;
using Zenject;

public interface IEnvironmentFactory
{
    Environment CreateEnvironment(eEnvironmentType environmentType);
}

public class EnvironmentFactory : IEnvironmentFactory
{
    readonly SimpleWallEnvironment.Factory  _SimpleWallEnvoFactory;
    readonly SimpleWallBg.Factory           _SimpleWallBg;

    public EnvironmentFactory(SimpleWallEnvironment.Factory _SimpleWallEnvoFactory)
    {
        this._SimpleWallEnvoFactory = _SimpleWallEnvoFactory;
    }

    public Environment CreateEnvironment(eEnvironmentType environmentType)
    {
        switch (environmentType)
        {
            case eEnvironmentType.SimpleWallEnvo:
                return _SimpleWallEnvoFactory.Create();

            case eEnvironmentType.SimpleWallBG:
                return _SimpleWallBg.Create();
        }
        return null;
    }
}

