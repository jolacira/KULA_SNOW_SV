using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volumesettings : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioMixer mainMixer;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    // Update is called once per frame
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        mainMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
}
