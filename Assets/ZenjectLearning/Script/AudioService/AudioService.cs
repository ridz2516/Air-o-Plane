using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoBehaviour, IAudioService
{
    public void PlaySound(string i_Type)
    {
        Debug.Log("Play Sound " + i_Type);
    }
}
