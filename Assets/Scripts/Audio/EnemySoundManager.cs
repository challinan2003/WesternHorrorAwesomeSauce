using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemySoundManager : MonoBehaviour
{
    public static EnemySoundManager instance;

    public AudioClip[] sfxList;
    public List<AudioResource> audioResources = new List<AudioResource>();

    //public GameObject sfxOneShotPrefab;
    public GameObject EnemySFXPrefab;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Update()
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
            //Destroy(gameObject);
        }
    }

    public void PlayAudioResource(int index, float pitchMultiplier = 1)
    {
        //EnemySFXPrefab = GameObject.Find("enemySFXOneShotPrefab");
        
        print("sound manager playing audio resource");
        var sfx = Instantiate(EnemySFXPrefab, transform.position, Quaternion.identity);
        AudioSource audioSource = sfx.GetComponent<AudioSource>();
        audioSource.pitch = audioSource.pitch * pitchMultiplier;
        sfx.GetComponent<EnemySFXScript>().PlaySFXOneShot(audioResources[index]);
    }
}

