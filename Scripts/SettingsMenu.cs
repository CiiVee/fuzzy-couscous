using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    private bool backPlay = true;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetBGM(float bgm)
    {
        audioMixer.SetFloat("bgm", bgm);
    }

    public void SetSFX(float sfx)
    {
        audioMixer.SetFloat("sfx", sfx);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void bgmToggle()
    {
        if (backPlay)
        {
            AudioListener.pause = true;
            backPlay = false;
        }
        else
        {
            AudioListener.pause = false;
            backPlay = true;
        }
    }
}
