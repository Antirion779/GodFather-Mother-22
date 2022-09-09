using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio")] 
    [SerializeField] private AudioClip collisionClip;
    [SerializeField] private AudioClip vanishClip;
    [SerializeField] private AudioClip playerDeathClip;
    [SerializeField] private AudioClip playerJumpClip;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void PlayCollision(Vector3 pos, float volume)
    {
        //Plays a clip once at a specific position, without an Audio Source
        AudioSource.PlayClipAtPoint(collisionClip ,  pos,  volume);
    }

    public void PlayVanish(Vector3 pos, float volume)
    {
        //Plays a clip once at a specific position, without an Audio Source
        AudioSource.PlayClipAtPoint(vanishClip, pos, volume);   
    }

    public void PlayPlayerDeath(Vector3 pos, float volume)
    {
        //Plays a clip once at a specific position, without an Audio Source
        AudioSource.PlayClipAtPoint(playerDeathClip, pos, volume);
    }

    public void PlayPlayerJump(Vector3 pos, float volume)
    {
        //Plays a clip once at a specific position, without an Audio Source
        AudioSource.PlayClipAtPoint(playerJumpClip, pos, volume);
    }
}
