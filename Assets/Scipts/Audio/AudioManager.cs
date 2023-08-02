using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public Slider sliderVolume;
    public Slider sliderSFX;
    public AudioMixer audioMixer;
   

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetVolume();
            SetVolumeSFX();
        }
    }   

    public void SetVolume()
    {
        float volume =  sliderVolume.value;
        audioMixer.SetFloat("volume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume); 
            
    }


    public void SetVolumeSFX()
    {
        float volume = sliderSFX.value;
        audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);

    }


    public void LoadVolume()
    {
        sliderVolume.value = PlayerPrefs.GetFloat("musicVolume");
        sliderSFX.value = PlayerPrefs.GetFloat("sfxVolume");
        SetVolume();
        SetVolumeSFX();
    }
}
