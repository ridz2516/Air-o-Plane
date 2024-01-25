
using UnityEngine;

public class AudioPlayer
{
    readonly AudioListner _AudioListner;

    public AudioPlayer(AudioListner _AudioListner)
    {
        this._AudioListner = _AudioListner;
    }

    public void Play(AudioClip clip)
    {
        Play(clip, 1);
    }

    public void Play(AudioClip clip, float volume)
    {
        _AudioListner.SfxAudioSource.PlayOneShot(clip, volume);
    }
}
