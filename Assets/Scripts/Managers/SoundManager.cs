using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;
    public AudioSource musicSource;
    public static SoundManager instance = null;            
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    public AudioClip[] CircleBlows;
    public AudioClip NormalMusic;
    public AudioClip RageMusic;
    public AudioClip RageDone;
    public AudioClip RageIdeal;
    public AudioClip GameOver;
    public AudioClip CoinCollect;
    public AudioClip RageOnSound;
    public AudioClip Right;
    public AudioClip Wrong;

    //это конечно тоже неправильно, но так быстрей и без лишней мороки с UIManager
    public Sprite SoundOn;
    public Sprite SoundOff;
    public GameObject[] SoundButtons;

    public bool IsPlayingDefault { get; set; }

    private void Awake()
    {
        currentMusicSpeed = defaultMusicSpeed;
    }

    public void StartNewGame()
    {
        currentMusicSpeed = defaultMusicSpeed;
    }

    public void PlayDefault()
    {
        if (!IsPlayingDefault)
        {
            musicSource.loop = true;
            musicSource.clip = NormalMusic;
            musicSource.pitch = defaultMusicSpeed;
            musicSource.Play();
            IsPlayingDefault = true;
        }
    }

    public void PlayNormal()
    {
        musicSource.loop = true;
        musicSource.clip = NormalMusic;
        musicSource.pitch = currentMusicSpeed;
        musicSource.Play();
        IsPlayingDefault = false;
    }

    public void PlayRageResult(RageModeResult rageModeResult)
    {
        AudioClip audioClip = null;
        switch (rageModeResult)
        {
            case RageModeResult.done:
                audioClip = RageDone;
                break;
            case RageModeResult.ideal:
                audioClip = RageIdeal;
                break;
            case RageModeResult.fail:
                audioClip = GameOver;
                break;
        }
        musicSource.loop = false;
        musicSource.clip = audioClip;
        musicSource.pitch = defaultMusicSpeed;
        musicSource.Play();
        IsPlayingDefault = false;
    }

    public void PlayGameOver()
    {
        musicSource.loop = false;
        musicSource.clip = GameOver;
        musicSource.pitch = defaultMusicSpeed;
        musicSource.Play();
        IsPlayingDefault = false;
    }

    public void PlayRage()
    {
        musicSource.loop = true;
        musicSource.clip = RageMusic;
        musicSource.pitch = defaultMusicSpeed;
        musicSource.Play();
        IsPlayingDefault = false;
    }

    public void PlayCircleBlow()
    {
        int randomIndex = Random.Range(0, CircleBlows.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        efxSource.pitch = randomPitch;
        efxSource.clip = CircleBlows[randomIndex];
        efxSource.Play();
    }

    public void IncreaseMusicSpeed()
    {
        currentMusicSpeed += 0.05f;
        musicSource.pitch = currentMusicSpeed;
        IsPlayingDefault = false;
    }

    public void PlayCoinCollect()
    {
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        efxSource.pitch = randomPitch;
        efxSource.clip = CoinCollect;
        efxSource.Play();
    }

    public void PlayRageOn()
    {
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        efxSource.pitch = randomPitch;
        efxSource.clip = RageOnSound;
        efxSource.Play();
    }

    public void PlayRightWrong(bool right)
    {
        AudioClip audioClip = right ? Right : Wrong;
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        efxSource.pitch = randomPitch;
        efxSource.clip = audioClip;
        efxSource.Play();
    }

    public void Mute(bool soundOn)
    {
        _soundOn = soundOn;
        efxSource.mute = !_soundOn;
        musicSource.mute = !_soundOn;
        foreach (var item in SoundButtons)
        {
            item.GetComponent<Image>().sprite = _soundOn ? SoundOn : SoundOff;
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    private float currentMusicSpeed;
    private bool _soundOn;
    private const float defaultMusicSpeed = 1.0f;
}
