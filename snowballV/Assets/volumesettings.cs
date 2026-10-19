using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumesettings : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioMixer mainmixer;

    private void Start()
    {
        if (PlayerPrefs.HasKey("prefsMusicvolume"))
        {
            LoadVolume();
        }
        else
        {
            setmusicVolume();
            setsfxVolume();
        }
    }
   
      

    public void setmusicVolume()
    {
        float volume = musicSlider.value;
        mainmixer.SetFloat("Musicvolume", Mathf.Log10(volume)*20);

        PlayerPrefs.SetFloat("prefsMusicvolume",volume);
    }



    public void setsfxVolume()
    {
        float volume = sfxSlider.value;
        mainmixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("prefsSFXvolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("prefsMusicvolume");
        sfxSlider.value = PlayerPrefs.GetFloat("prefsSFXvolume");
    }
}


