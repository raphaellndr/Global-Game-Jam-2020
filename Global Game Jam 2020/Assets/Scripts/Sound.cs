using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)] //add a slider to the volume
    public float volume;
    [Range(.1f, 3f)] //add a slider to the pitch
    public float pitch;

    public bool loop;

    [HideInInspector] //even if it's public it won't show up
    public AudioSource source;
}