using UnityEngine;
using System;
using UnityEngine.Audio;

[System.Serializable]

public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 2f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
