using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource[] _effectsSources;

    private float masterVolume = 0.15f;
    private float musicVolume = 1.0f;
    private float effectsVolume = 1.0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

            //Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        foreach (var effectsSource in _effectsSources)
        {
            effectsSource.PlayOneShot(clip, effectsVolume);
        }
    }

    public void ChangeMasterVolume(float volume)
    {
        masterVolume = volume;
        AudioListener.volume = masterVolume;
    }

    public void ChangeMusicVolume(float volume)
    {

        musicVolume = volume;
        Debug.Log($"Changing Music Volume to: {volume}");
        _musicSource.volume = musicVolume;
    }

    public void ChangeEffectsVolume(float volume)
    {
        effectsVolume = volume;
        Debug.Log($"Changing Effects Volume to: {volume}");
        foreach (var effectSource in _effectsSources)
        {
            effectSource.volume = volume;
        }
    }

    public float GetMasterVolume()
    {
        return masterVolume;
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public float GetEffectsVolume()
    {
        return effectsVolume;
    }

    public void ToggleEffects()
    {
        foreach (var effectsSource in _effectsSources)
        {
            effectsSource.mute = !effectsSource.mute;
        }
    }

    public void ToggleMusic()
    {
        _musicSource.mute = !_musicSource.mute;
    }
}
