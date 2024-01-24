

public class PlaneStateFactory
{
    readonly PlaneStateIdle.Factory _PlaneStateIdle;
    readonly PlaneStateMoving.Factory _PlaneStateMoving;
    readonly PlaneStateTakeOff.Factory _PlaneStateTakeOff;
    

    public PlaneStateFactory(PlaneStateIdle.Factory _PlaneStateIdle, PlaneStateMoving.Factory _PlaneStateMoving, PlaneStateTakeOff.Factory _PlaneStateTakeOff)
    {
        this._PlaneStateIdle    = _PlaneStateIdle;
        this._PlaneStateMoving  = _PlaneStateMoving;
        this._PlaneStateTakeOff = _PlaneStateTakeOff;
    }

    public PlaneState CreateState(ePlaneStates m_StateType)
    {
        switch (m_StateType)
        {
            case ePlaneStates.Idle:
                return _PlaneStateIdle.Create();

            case ePlaneStates.Moving:
                return _PlaneStateMoving.Create();

            case ePlaneStates.TakeOff:
                return _PlaneStateTakeOff.Create();
        }

        return null;
    }
}
