using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //  Create array to store all audio clips used in game.
    public Sound[] sounds;
    //  Establish instance of Audio Manager to be used throughout scenes.
    public static AudioManager instance;

    //  Initialize an instance of Audio Manager:
    //  If one already exists, destroy the object so there are not multiples.
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }


        //  Roll through the sounds array to get values from fields.
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    //  Function will play the selected audio clip.
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    //  Function will stop playing the selected audio clip.
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}
