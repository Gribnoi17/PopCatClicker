using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip _meowClip;
    private AudioSource _source;

    private void Start()
    {
        EventManager.Clicked += PlayMeowClip;
        EventManager.MusicChanged += EnableAndDisableMusic;
        _source = GetComponent<AudioSource>();
    }

    private void PlayMeowClip()
    {
        _source.PlayOneShot(_meowClip);
    }

    private void EnableAndDisableMusic()
    {
        if (_source.volume > 0)
        {
            _source.volume = 0;
        }
        else
        {
            _source.volume = 0.5f;
        }
    }

    private void OnDestroy()
    {
        EventManager.Clicked -= PlayMeowClip;
    }
}
