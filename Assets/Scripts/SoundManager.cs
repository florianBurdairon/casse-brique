using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private AudioSource effectsource;

    public AudioClip ballHitPaddle;
    public AudioClip ballHitBrick;
    public AudioClip loseOneLife;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        this.effectsource = this.AddComponent<AudioSource>();
    }

    public void PlayBallHitPaddle()
    {
        this.effectsource.PlayOneShot(ballHitPaddle);
    }
    public void PlayBallHitBrick()
    {
        this.effectsource.PlayOneShot(ballHitBrick);
    }
    public void PlayLoseOneLife()
    {
        this.effectsource.PlayOneShot(loseOneLife);
    }
}
