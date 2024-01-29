
using UnityEngine;
using Zenject;

public class Obstacle : MonoBehaviour
{
    #region Data

    [SerializeField] private Transform[]    _AllMovementPoints;
    [SerializeField] private Transform      _MainPlatform;
    [SerializeField] private eObstacleType  _TargetType;

    private ObstacleBase    _ObstacleType;
    private ObstacleFactory _ObstacleFactory;

    #endregion Data

    [Inject]
    public void Construct(ObstacleFactory _ObstacleFactory)
    {
        this._ObstacleFactory   = _ObstacleFactory;
    }

    #region Init

    private void Start()
    {
        setObstacle();
    }

    private void OnDisable()
    {
        if(_ObstacleType != null)
            _ObstacleType.Deactivate();
    }


    #endregion Init

    private void Update()
    {
        _ObstacleType.Update();
    }

    #region Unity Physics

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(nameof(eTags.Player)))
        {
            _ObstacleType.OnTriggerEnter(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(nameof(eTags.Player)))
        {
            _ObstacleType.OnTriggerExit(other);
        }
    }

    #endregion Unity Physics


    private void setObstacle()
    {
        _ObstacleType = _ObstacleFactory.CreateObstacleType(_TargetType);
        _ObstacleType.SetObstacle(this);
        _ObstacleType.Start();
    }

    public Transform MainPlatform
    {
        get => _MainPlatform;
    }

    public Vector3 Position
    {
        set => _MainPlatform.position = value;
        get => _MainPlatform.position;
    }

    public Quaternion Rotation
    {
        set => _MainPlatform.rotation = value;
    }

    public Transform[] GetMovementPoints
    {
        get => _AllMovementPoints;
    }
}
