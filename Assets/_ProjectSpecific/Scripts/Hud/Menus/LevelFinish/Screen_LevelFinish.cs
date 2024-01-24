using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen_LevelFinish : MonoBehaviour, IMenuView
{
    public Button RestartButton;

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
