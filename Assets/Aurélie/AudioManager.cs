using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public List<AudioClip> _clips = new List<AudioClip>();
    public List<AudioSource> _sources = new List<AudioSource>();

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < _sources.Count; i++)
        {
            _sources[i].clip = _clips[i];
        }
    }

    public void Play(string name)
    {
        _sources.Find(x => x.clip.name.ToLower().Contains(name)).Play();
    }
}