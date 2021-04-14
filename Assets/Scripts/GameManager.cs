using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Sound Effects")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    [Header("Background Music")]
    [SerializeField] private AudioSource backgroundSource;
    [SerializeField] private AudioClip[] backgroundMusicClips;

    private void Update()
    {
        BackGroundMusic(false);
    }

    public void PlaySound(int audioClip)
    {
        audioSource.PlayOneShot(audioClips[audioClip]);
    }

    public void BackGroundMusic(bool bossFightMusic)
    {
        if(bossFightMusic == true)
        {
            backgroundSource.Stop();
            backgroundSource.PlayOneShot(backgroundMusicClips[backgroundMusicClips.Length]);
            backgroundSource.loop = true;
        }

        if (backgroundSource.isPlaying == false && bossFightMusic == false)
        {
            backgroundSource.PlayOneShot(backgroundMusicClips[Random.Range(0, backgroundMusicClips.Length)]);
        }
    }
}
