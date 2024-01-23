using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnvironmentLooper : ILooper
{
    readonly IPlayerMovementHandler _IMovementPlayer;

    private IEnvironmentChunk[] elements;
    private int currentIndex = 0;
    private int futureIndex = 0;
    private float _distanceBetweenEnvironment;

    public EnvironmentLooper(IPlayerMovementHandler _IMovementPlayer)
    {
        this._IMovementPlayer = _IMovementPlayer;
    }

    public void Initialize()
    {
        deactivateElement();

        futureIndex = (currentIndex + 1) % elements.Length;
        activateElement(futureIndex);
        activateElement(currentIndex);

        elements[futureIndex].SetPosition(elements[currentIndex].GetEndPoint().position + new Vector3(_distanceBetweenEnvironment, 0, 0));

    }

    public void UpdateDistance(float loopDistance)
    {
        float distanceToNext = elements[currentIndex].GetEndPoint().position.x - _IMovementPlayer.Position.x;

        if (distanceToNext <= loopDistance)
        {
            deactivateElement();
            currentIndex = (currentIndex + 1) % elements.Length;
            futureIndex = (currentIndex + 1) % elements.Length;
            activateElement(futureIndex);
            activateElement(currentIndex);

            elements[futureIndex].SetPosition(elements[currentIndex].GetEndPoint().position + new Vector3(_distanceBetweenEnvironment, 0, 0));
        }
    }

    public void UpdateElements(IEnvironmentChunk[] _newElements, float _distance)
    {
        elements = _newElements;
        _distanceBetweenEnvironment = _distance;
        Initialize();
    }

    private void activateElement(int index)
    {
        elements[index].GetMainObject().SetActive(true);
    }

    private void deactivateElement()
    {
        foreach (var item in elements)
        {
            item.GetMainObject().SetActive(false);
        }
    }
}


