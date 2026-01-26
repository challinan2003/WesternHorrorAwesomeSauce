using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemySoundManager : MonoBehaviour
{
    public static EnemySoundManager instance;

    public AudioClip[] sfxList;
    public List<AudioResource> audioResources = new List<AudioResource>();

    public GameObject enemySFXOneShotPrefab;


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


        sfx = Instantiate(enemySFXOneShotPrefab, transform.position, Quaternion.identity);


        AudioSource audioSource = sfx.GetComponent<AudioSource>();
        audioSource.pitch = audioSource.pitch * pitchMultiplier;
        sfx.GetComponent<SFXOneShotPrefab>().PlaySFXOneShot(sfxList[index]);
    }

    public void PlayAudioResource(int index, float pitchMultiplier = 1)
    {
        print("sound manager playing audio resource");
        var sfx = Instantiate(enemySFXOneShotPrefab, transform.position, Quaternion.identity);
        AudioSource audioSource = sfx.GetComponent<AudioSource>();
        audioSource.pitch = audioSource.pitch * pitchMultiplier;
        sfx.GetComponent<EnemySFXScript>().PlaySFXOneShot(audioResources[index]);
    }
}

