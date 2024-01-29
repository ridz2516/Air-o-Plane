
public class ObstacleFactory
{
    readonly ObstacleMoving.Factory _ObstacleMovingFactory;
    readonly ObstacleIndianaState.Factory _ObstacleIndianaFactory;

    public ObstacleFactory(ObstacleMoving.Factory _ObstacleFactory,
        ObstacleIndianaState.Factory _ObstacleIndianaFactory)
    {
        this._ObstacleMovingFactory = _ObstacleFactory;
        this._ObstacleIndianaFactory = _ObstacleIndianaFactory;
    }

    public ObstacleBase CreateObstacleType(eObstacleType _eObstacleType)
    {
        switch (_eObstacleType)
        {
            case eObstacleType.Moving:
                return _ObstacleMovingFactory.Create();

            case eObstacleType.IndianaJonesStyle:
                return _ObstacleIndianaFactory.Create();
        }

        return _ObstacleMovingFactory.Create();
    } 
}
