

using Zenject;

public class PlaneStateFactory
{
    readonly PlaneStateIdle.Factory _PlaneStateIdle;
    readonly PlaneStateMoving.Factory _PlaneStateMoving;
    

    public PlaneStateFactory(PlaneStateIdle.Factory _PlaneStateIdle, PlaneStateMoving.Factory _PlaneStateMoving)
    {
        this._PlaneStateIdle = _PlaneStateIdle;
        this._PlaneStateMoving = _PlaneStateMoving;
    }

    public PlaneState CreateState(ePlaneStates m_StateType)
    {
        switch (m_StateType)
        {
            case ePlaneStates.Idle:
                return _PlaneStateIdle.Create();

            case ePlaneStates.Moving:
                return _PlaneStateMoving.Create();
        }

        return null;
    }
}
