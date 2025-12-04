using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip[] sfxList;
    public List<AudioResource> audioResources = new List<AudioResource>();

    public GameObject sfxOneShotPrefab;
    //public GameObject EnemySFXPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
       // EnemySFXPrefab = GameObject.Find("enemySFXOneShotPrefab");
    }
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlaySFX(int index, float pitchMultiplier = 1)
    {
        GameObject sfx;
        
        
        sfx = Instantiate(sfxOneShotPrefab, transform.position, Quaternion.identity);
        
        
        AudioSource audioSource = sfx.GetComponent<AudioSource>();
        audioSource.pitch = audioSource.pitch * pitchMultiplier;
        sfx.GetComponent<SFXOneShotPrefab>().PlaySFXOneShot(sfxList[index]);
    }

    public void PlayAudioResource(int index, float pitchMultiplier = 1)
    {
        print("sound manager playing audio resource");
        var sfx = Instantiate(sfxOneShotPrefab, transform.position, Quaternion.identity);
        AudioSource audioSource = sfx.GetComponent<AudioSource>();
        audioSource.pitch = audioSource.pitch * pitchMultiplier;
//        sfx.GetComponent<SFXOneShotPrefab>().PlaySFXOneShot(audioResources[index]);
    }
}


