using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    public bool isOn = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        if (!isOn) return;
        Play("Theme");
    }

    private void Update()
    {
        if (isOn && !isPlaying("Theme"))
            Play("Theme");
        else if(!isOn && isPlaying("Theme"))
            Stop("Theme");
    }


    public void Play(string name)
    {
        if (!isOn) return;
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("AudioSource with name" + name + " not found.");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("AudioSource with name" + name + " not found.");
            return;
        }
        s.source.Stop();
    }

    public bool isPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("AudioSource with name" + name + " not found.");
            return false;
        }
        return s.source.isPlaying;
    }



    public void SetMusicVolume(float n)
    {
        Sound s = Array.Find(sounds, sound => sound.name == "Theme");
        if (s == null)
        {
            Debug.Log("AudioSource with name" + name + " not found.");
            return;
        }
        s.volume = n;
        s.source.volume = n;
    }

    public void SetSoundVolume(float n)
    {
        foreach (Sound s in sounds)
        {
            if(s.name != "Theme")
            {
                s.volume = n;
                s.source.volume = n;
            }
        }
    }
}
