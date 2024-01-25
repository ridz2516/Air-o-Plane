using UnityEngine;

public class AudioListner : MonoBehaviour
{
    [SerializeField] AudioSource _SfxAudioSource;
    public AudioSource SfxAudioSource => _SfxAudioSource;
}
