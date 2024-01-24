
using UnityEngine;
using Zenject;

public class PlayerPlane : MonoBehaviour, IPlayerController, IPlayerStatesHandler
{
    #region Data

    [SerializeField] private Animator _PlaneAnimation;
    [SerializeField] private TrailRenderer _TrailRenderer;

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

    #region Unity Physics

    public void OnTriggerEnter2D(Collider2D collision)
    {
        _PlayerState.OnTriggerEnter(collision);
    }

    #endregion Unity Physics

    public void SetAnimation(eAnimation _eAnimation)
    {
        _PlaneAnimation.SetTrigger(_eAnimation.ToString());
    }

    public TrailRenderer TrailRenderer
    {
        get => _TrailRenderer;
        set => _TrailRenderer = value;
    }

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

    public Vector3 LocalEular
    {
        get => transform.localEulerAngles;
        set => transform.localEulerAngles = value;
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
