using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip Intro;

    public AudioClip[] music;

    public AudioSource randomMusic;

    void Awake() 
    {
        randomMusic = gameObject.GetComponent<AudioSource>();
        randomMusic.clip = Intro;
        randomMusic.Play();
        Invoke("PlayNextSong", randomMusic.clip.length);
    }

    void PlayNextSong(){
        randomMusic.clip = music[Random.Range(0,music.Length)];
        randomMusic.Play();
        randomMusic.loop = true;
    }
}
