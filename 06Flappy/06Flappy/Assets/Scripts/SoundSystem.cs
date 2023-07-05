using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static SoundSystem;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem instance;

    [SerializeField] AudioSource audioBackground;

    [SerializeField] AudioSource audioSourceScore;
    [SerializeField] AudioSource audioSourceFlap;
    [SerializeField] AudioSource audioSourceHit;
    [SerializeField] AudioSource audioSourceCoin;
    private void Awake()
    {
        if (SoundSystem.instance == null)
        {
            SoundSystem.instance = this;
        }else if (SoundSystem.instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayScore()
    {
       audioSourceScore.Play();
    }
    public void PlayFlap()
    {
        audioSourceFlap.Play();
    }
    public void PlayHit()
    {
        audioBackground.Stop();
        audioSourceHit.Play();
    }

    public void PlayCoin()
    {
        audioSourceCoin.Play();
    }
    void OnDestroy()
    {
        if (SoundSystem.instance == this)
        {
            instance = null;
        }
    }
}

