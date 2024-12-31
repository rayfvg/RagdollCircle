using UnityEngine;
using static Unity.VisualScripting.Member;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource; // �������� ������� ������
    public AudioSource[] soundSources; // ��������� ��� ������

    [Header("Settings")]
    public bool isMusicEnabled = true; // ���������/���������� ������
    public bool areSoundsEnabled = true; // ���������/���������� ������


    private void Awake()
    {
        // Singleton ��� ����������� �������
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

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            StopAllSouds();
        }
        else
        {
            PlayAllSounds();
        }
    }

    public void ToggleMusic(bool isEnabled)
    {
        isMusicEnabled = isEnabled;
        musicSource.mute = !isMusicEnabled; // ��������� ���� � ���������
    }

    public void ToggleSounds(bool isEnabled)
    {
        areSoundsEnabled = isEnabled;
        foreach (var source in soundSources)
        {
            source.mute = !areSoundsEnabled; // ��������� ���� � ������� ���������
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (!areSoundsEnabled) return;

        // ���� ��������� �������� ��� ���������������
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

    public void StopAllSouds()
    {
        musicSource.Pause();
        foreach (var item in soundSources)
        {
            item.Pause();
        }
    }

    public void PlayAllSounds()
    {
        musicSource.UnPause();
        foreach (var item in soundSources)
        {
            item.UnPause();
        }
    }
}
