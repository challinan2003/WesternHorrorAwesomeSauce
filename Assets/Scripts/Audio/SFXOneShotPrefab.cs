using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SFXOneShotPrefab : MonoBehaviour
{
    private AudioSource _as;
    private AudioClip clipPlaying = null;
    void OnEnable()
    {
        _as = GetComponent<AudioSource>();
    }

    public void PlaySFXOneShot(AudioClip clip)
    {
        clipPlaying = clip;
        _as.PlayOneShot(clip);
        StartCoroutine(KillMyself());
    }

    public void PlaySFXOneShot(AudioResource resource)
    {
        _as.resource = resource;
        _as.Play();
        StartCoroutine(KillMyself());
    }

    IEnumerator KillMyself()
    {
        if (clipPlaying != null)
        {
            yield return new WaitForSeconds(clipPlaying.length + 0.1f);
        }
        else
        {
            yield return new WaitUntil(IsDonePlaying);
        }
        Destroy(gameObject);
    }

    bool IsDonePlaying()
    {
        return !_as.isPlaying;
    }
}
