using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Audio manager is not present!");
            }
            return _instance;
        }
    }

    public AudioSource VO;
    public AudioSource Music;

    private void Awake()
    {
        _instance = this;
    }

    public void Play(AudioClip clip)
    {
        VO.clip = clip;
        VO.Play();
    }

    public void PlayMusic()
    {
        Music.Play();
    }
}
