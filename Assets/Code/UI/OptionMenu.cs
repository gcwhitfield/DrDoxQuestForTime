using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public Slider music;
    public Slider SFX;

    private void Start()
    {
        MusicVolumeSliderChanged(music.value);
        SFXSliderVolumeChanged(SFX.value);
    }

    public void MusicVolumeSliderChanged(float amt)
    {
        SetVolume("bus:/Music", amt);
    }

    public void SFXSliderVolumeChanged(float amt)
    {
        SetVolume("bus:/SFX", amt);
    }

    void SetVolume(string busPath, float amt)
    {
        if (amt < 0 || amt > 1)
        {
            return;
        }
        FMOD.Studio.Bus bus = FMODUnity.RuntimeManager.GetBus(busPath);
        bus.setVolume(amt);
    }
}
