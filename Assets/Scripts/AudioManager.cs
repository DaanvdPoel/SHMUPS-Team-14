using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Sound Effects")]
    [SerializeField] private AudioSource audioSource;
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
        if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(audioClips[audioClip]);
        }
    }

    //Doe alle backgroundmusic in de backgroundMusicClips array. het laatste muziekje in de array word gebruikt voor de boss fight.
    public void BackGroundMusic()
    {
        int random = Random.Range(0, backgroundMusicClips.Length - 1);

        //if (bossFightMusic == true && backgroundMusicClips[random].name != backgroundMusicClips[backgroundMusicClips.Length].name)
        //{
        //    if (backgroundSource.isPlaying == false)
        //    {
        //        backgroundSource.PlayOneShot(backgroundMusicClips[backgroundMusicClips.Length - 1]);
        //        backgroundSource.loop = true;
        //        Debug.Log("Now Playing: " + backgroundMusicClips[random].name);
        //    }
        //}

        if (backgroundSource.isPlaying == false && bossFightMusic == false)
        {
            backgroundSource.PlayOneShot(backgroundMusicClips[random]);
            backgroundSource.loop = false;
            Debug.Log("Now Playing: "+ backgroundMusicClips[random].name);
        }
    }
}
