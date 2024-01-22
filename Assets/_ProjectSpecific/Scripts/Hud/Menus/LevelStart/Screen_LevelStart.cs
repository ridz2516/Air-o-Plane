using UnityEngine;
using UnityEngine.UI;

public class Screen_LevelStart : MonoBehaviour, IMenuView
{
    public Button PlayButton;
    public Button TutorialButton;

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
