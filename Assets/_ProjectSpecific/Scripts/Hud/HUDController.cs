using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public ExtendedButton InputButton;

    public Action<Vector2> OnInputDown;
    public Action OnInputUp;

    private void OnEnable()
    {
        InputButton.OnDownEvent += inputDown;
        InputButton.OnUpEvent   += inputUp;
    }

    private void OnDisable()
    {
        InputButton.OnDownEvent -= inputDown;
        InputButton.OnUpEvent   -= inputUp;
    }

    private void inputDown(PointerEventData eventData)
    {
        OnInputDown?.Invoke(Input.mousePosition);
    }

    private void inputUp(PointerEventData eventData)
    {
        OnInputUp?.Invoke();
    }
}
