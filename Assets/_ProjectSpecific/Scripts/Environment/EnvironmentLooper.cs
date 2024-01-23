using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentLooper<T> : ILooper where T : Component
{
    private T[] elements;
    private int currentIndex = 0;

    public EnvironmentLooper(T[] elements)
    {
        this.elements = elements;

        if (this.elements.Length > 0)
        {
            ActivateElement(currentIndex);
        }
        else
        {
            Debug.LogError($"No elements assigned to {typeof(T).Name}Looper!");
        }
    }

    public void UpdateDistance(float loopDistance)
    {
        float distanceToNext = Vector3.Distance(Vector3.zero, elements[currentIndex].transform.position);

        if (distanceToNext >= loopDistance)
        {
            DeactivateElement(currentIndex);
            currentIndex = (currentIndex + 1) % elements.Length;
            ActivateElement(currentIndex);
        }
    }

    private void ActivateElement(int index)
    {
        elements[index].gameObject.SetActive(true);
    }

    private void DeactivateElement(int index)
    {
        elements[index].gameObject.SetActive(false);
    }
}

public interface ILooper
{
    void UpdateDistance(float loopDistance);
}
