using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private const string PLAYER_PREFS_SOUND_EFFECTS_VOLUME = "SoundEffectsVolume";

    private bool isCountDownStarted = false;
    

    [SerializeField] public AudioClipsRefsSO audioClipRefsSO;

    private float volume = 1f;

    private void Awake()
    {
        Instance = this;
        isCountDownStarted = false;
    }

    private void Update()
    {
        if (!isCountDownStarted && GameManager.Instance.IsCountdownToStartActive()) 
        {
            //PlaySound(audioClipRefsSO.countdownSound, Camera.main.transform.position, 0.3f);
            isCountDownStarted = true;
        }
    }

    public void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier * volume);
    }

    public void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipArray[UnityEngine.Random.Range(0, audioClipArray.Length)], position, volume);
    }

    public void ChangeVolume()
    {
        volume += .1f;
        if (volume > 1f) volume = 0f;

        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, volume);
        PlayerPrefs.Save();
    }

    public float GetVolume() { return volume; }
}
