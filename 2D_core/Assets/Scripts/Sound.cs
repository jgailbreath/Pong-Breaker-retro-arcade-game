using UnityEngine;
using System;
using UnityEngine.Audio;

[System.Serializable]
//  Class which holds fields to house the various settings from
//  the audio clips stored in array.
public class Sound
{
    public string name;

    public int priority;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 2f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
