using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private bool mute=true;

    public Sound[] sounds;

    public Sprite ButtonON;
    public Sprite ButtonOFF;

    void Awake()
    {
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void muteToggle(){

        if(mute){
            AudioListener.volume = 0;
            mute = false;
            GameObject.Find("Button").GetComponent<Image>().sprite = ButtonOFF;

        }else{
            AudioListener.volume = 1;
            mute = true;
            GameObject.Find("Button").GetComponent<Image>().sprite = ButtonON;
        }
    }


}
