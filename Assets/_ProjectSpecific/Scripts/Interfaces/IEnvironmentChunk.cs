
using UnityEngine;

public interface IEnvironmentChunk
{
    public Transform GetEndPoint();
    public GameObject GetMainObject();
    public void SetPosition(Vector3 _newPosition);
}
