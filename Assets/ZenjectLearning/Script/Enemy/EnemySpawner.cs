using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    private IAudioService _audioService;

    [Inject]
    private void Construct(IAudioService i_AudioService)
    {
        _audioService = i_AudioService;
    }


}
