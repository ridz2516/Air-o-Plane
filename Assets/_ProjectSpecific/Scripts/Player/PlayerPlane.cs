
using UnityEngine;
using Zenject;

public class PlayerPlane : MonoBehaviour, IPlayerMovementHandler, IPlayerStatesHandler
{
    #region Data

    private PlaneStateFactory _PlaneStateFactory;
    private PlaneState _PlayerState;

    private ePlaneStates _CurrentPlaneState;

    #endregion Data

    #region Initialize

    [Inject]
    public void Construct(PlaneStateFactory _PlaneStateFactory)
    {
        this._PlaneStateFactory = _PlaneStateFactory;

    }

    private void Start()
    {
        ChangeState(ePlaneStates.Idle);
    }


    #endregion Initialize

    #region Unity Loop

    private void Update()
    {
        _PlayerState.Update();
    }

    #endregion Unity Loop


    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }

    public Quaternion Rotation
    {
        get => transform.localRotation;
        set => transform.localRotation = value;
    }

    public Vector3 GetForward => transform.forward;

    public ePlaneStates CurrentState => _CurrentPlaneState;

    public void ChangeState(ePlaneStates _eType)
    {
        if(_PlayerState != null)
        {
            _PlayerState.Dispose();
        }

        _PlayerState = _PlaneStateFactory.CreateState(_eType);
        _PlayerState.Start();
    }
}
