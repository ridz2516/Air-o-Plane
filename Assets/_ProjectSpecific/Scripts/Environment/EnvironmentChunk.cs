
using UnityEngine;

public class EnvironmentChunk : MonoBehaviour, IEnvironmentChunk
{
    [SerializeField] private Transform  _EndPoint;


    public Transform GetEndPoint()
    {
        return _EndPoint;
    }

    public void SetPosition(Vector3 _newPosition)
    {
        transform.position = _newPosition;
    }

    public GameObject GetMainObject()
    {
        return this.gameObject;
    }
}
