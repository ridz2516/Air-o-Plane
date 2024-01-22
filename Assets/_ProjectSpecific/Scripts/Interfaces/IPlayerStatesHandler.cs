

public interface IPlayerStatesHandler
{
    public void ChangeState(ePlaneStates _eType);
    public ePlaneStates CurrentState { get; }
}
