using System;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSounds : MonoBehaviour
{
    public static ManagerSounds Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach (var audioSource in audioSources)
        {
            _sounds.Add(audioSource.clip.name, audioSource);
        }
    }
   private Dictionary<string, AudioSource> _sounds = new Dictionary<string, AudioSource>();

    public void PlaySound(string namez)
    {
        if (_sounds.ContainsKey(namez))
        {
            _sounds[namez].Play();
        }
        else
        {
            Debug.LogError("Không tìm thấy sound: " + namez);
        }
    }

    public void StopSound(string namez)
    {
        if (_sounds.ContainsKey(namez))
        {
            _sounds[namez].Stop();
        }
    }

    public void StopALL()
    {
        foreach (var sound in _sounds)
        {
            StopSound(sound.Key);
        }
    }


    private void Start()
    {
        StopALL();
    }
}