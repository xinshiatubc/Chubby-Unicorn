using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    //Loop through the sounds and add audio source;
    void Awake()
    {
        //If no audio manager present, set this to be the one.
        if (instance == null)
            instance = this;
        //Destroy duplicate
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        PlayAudio("Background");
    }

    public void PlayAudio(string name)
    {
        //find certain sound clip
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        //Sound not found
        if(s == null)
        {
            return;
        }
        s.source.Play();
    }
}
