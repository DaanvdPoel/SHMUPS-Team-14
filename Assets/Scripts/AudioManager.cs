using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Sound Effects")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private AudioClip[] audioClips;
    [Header("Background Music")]
    [SerializeField] private AudioSource backgroundSource;
    [SerializeField] private AudioClip[] backgroundMusicClips;
    public bool bossFightMusic;

    private void Update()
    {
        BackGroundMusic();
    }

    //roep deze funsie in een andere script op en geeft hem het array nummer van de audio clip die je wilt afspelen.
    public void PlaySound(int audioClip)
    {
        if(audioSource2.isPlaying == false)
        {
            audioSource2.PlayOneShot(audioClips[audioClip]);
        }
    }

    public void PlayPlayerSound(int audioClip)
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(audioClips[audioClip]);
        }

    }

    //Doe alle backgroundmusic in de backgroundMusicClips array. het laatste muziekje in de array word gebruikt voor de boss fight.
    public void BackGroundMusic()
    {
        int random = Random.Range(0, backgroundMusicClips.Length - 2);

        if (backgroundSource.isPlaying == false && bossFightMusic == false)
        {
            backgroundSource.PlayOneShot(backgroundMusicClips[random]);
            backgroundSource.loop = false;
            Debug.Log("Now Playing: " + backgroundMusicClips[random].name);
        }
    }

    public void PlayBossFightMusic()
    {
        backgroundSource.PlayOneShot(backgroundMusicClips[backgroundMusicClips.Length - 1]);
        backgroundSource.loop = true;
        Debug.Log("Now Playing bossfightmusic");
    }

    public void StopPlayingBackgroundMusic()
    {
        backgroundSource.Stop();
        audioSource2.Stop();
    }
}
