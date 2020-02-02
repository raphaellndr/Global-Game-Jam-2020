using UnityEngine.Audio;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public List<Sound> sounds;

    List<Sound> tmp = new List<Sound>();

    /*private float minPitch = 0.5f;
    private float maxPitch = 1f;*/

    public static AudioManager instance; //static reference to the current used AudioManager on the scene

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) //there is no AudioManager in the scene
        {
            instance = this;
        }
        else
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
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    public void Play(string name)
    {
        //Sound s = Array.Find(sounds, sound => sound.name == name);

        Sound s = sounds.Find(sound => sound.name == name);
        if (s == null) //if the song doens't exist (wrong spelling)
        {
            Debug.LogWarning("Sound : " + name + " not found");
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        //Sound s = Array.Find(sounds, sound => sound.name == name);

        Sound s = sounds.Find(sound => sound.name == name);
        if (s == null) //if the song doens't exist (wrong spelling)
        {
            Debug.LogWarning("Sound : " + name + " not found");
            return;
        }
        s.source.Stop();
    }

    /*void Update()
    {
        foreach (Sound s in sounds)
        {
            if (!PauseMenu.GameIsPaused || PauseMenu.pause == false)
            {
                s.source.pitch += 0.01f;
                s.source.pitch = Mathf.Clamp(s.source.pitch, minPitch, maxPitch);
            }
            else
            {
                s.source.pitch -= 0.01f;
                s.source.pitch = Mathf.Clamp(s.source.pitch, minPitch, maxPitch);
            }
        }

        foreach (Sound s in sounds)
        {
            if (PauseMenu.pause == false)
            {
                s.source.pitch = 1f;
            }
        }
    }*/
}