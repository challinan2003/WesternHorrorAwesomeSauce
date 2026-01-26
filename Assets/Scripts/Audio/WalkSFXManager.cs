using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WalkSFXManager : MonoBehaviour
{
    public static WalkSFXManager instance;

    public AudioClip[] walkSfxList;
    public List<AudioResource> WalkaudioResources = new List<AudioResource>();

    public GameObject WalkSFXOneShotPrefab;


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


        sfx = Instantiate(WalkSFXOneShotPrefab, transform.position, Quaternion.identity);

        AudioSource audioSource = sfx.GetComponent<AudioSource>();
        audioSource.pitch = audioSource.pitch * pitchMultiplier;
        sfx.GetComponent<SFXOneShotPrefab>().PlaySFXOneShot(walkSfxList[index]);
    }
    public void PlayAudioResource(int index, float pitchMultiplier = 1)
    {
        print("sound manager playing audio resource");
        var sfx = Instantiate(WalkSFXOneShotPrefab, transform.position, Quaternion.identity);
        AudioSource audioSource = sfx.GetComponent<AudioSource>();
        audioSource.pitch = audioSource.pitch * pitchMultiplier;
        //        sfx.GetComponent<SFXOneShotPrefab>().PlaySFXOneShot(audioResources[index]);
    }
}
