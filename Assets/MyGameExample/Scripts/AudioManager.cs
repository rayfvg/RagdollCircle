using UnityEngine;
using static Unity.VisualScripting.Member;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource; // Источник фоновой музыки
    public AudioSource musicSource1; // Источник фоновой музыки
    public AudioSource[] soundSources; // Источники для звуков

    [Header("Settings")]
    public bool isMusicEnabled = true; // Включение/выключение музыки
    public bool areSoundsEnabled = true; // Включение/выключение звуков


    private void Awake()
    {
        // Singleton для глобального доступа
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void ToggleMusic(bool isEnabled)
    {
        isMusicEnabled = isEnabled;
        musicSource.mute = !isMusicEnabled; // Выключаем звук у источника
        musicSource1.mute = !isMusicEnabled;
    }

    public void ToggleSounds(bool isEnabled)
    {
        areSoundsEnabled = isEnabled;
        foreach (var source in soundSources)
        {
            source.mute = !areSoundsEnabled; // Выключаем звук у каждого источника
        }

      
    }

    public void PlaySound(AudioClip clip)
    {
        if (!areSoundsEnabled) return;

        // Ищем свободный источник для воспроизведения
        foreach (var source in soundSources)
        {
            if (!source.isPlaying)
            {
                source.clip = clip;
                source.Play();
                return;
            }
        }
    }
}
