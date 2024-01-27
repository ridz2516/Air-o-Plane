

public class PlaneStateFactory
{
    readonly PlaneStateIdle.Factory     _PlaneStateIdle;
    readonly PlaneStateMoving.Factory   _PlaneStateMoving;
    readonly PlaneStateDead.Factory     _PlaneStateDead;
    

    public PlaneStateFactory(PlaneStateIdle.Factory _PlaneStateIdle,
        PlaneStateMoving.Factory _PlaneStateMoving,
        PlaneStateDead.Factory _PlaneStateDead)
    {
        this._PlaneStateIdle    = _PlaneStateIdle;
        this._PlaneStateMoving  = _PlaneStateMoving;
        this._PlaneStateDead = _PlaneStateDead;
    }

    public PlaneState CreateState(ePlaneStates m_StateType)
    {
        switch (m_StateType)
        {
            case ePlaneStates.Idle:
                return _PlaneStateIdle.Create();

            case ePlaneStates.Moving:
                return _PlaneStateMoving.Create();

            case ePlaneStates.Dead:
                return _PlaneStateDead.Create();
        }

        return null;
    }
}
