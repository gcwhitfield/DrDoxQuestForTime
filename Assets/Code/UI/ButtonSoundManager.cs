using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundManager : MonoBehaviour
{
    public void OnButtonHovered()
    {
        FMOD.Studio.EventInstance evt;
        evt = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Button SFX/Button Hover");
        evt.start();
        evt.release();
    }

    public void OnButtonPressed()
    {
        FMOD.Studio.EventInstance evt;
        evt = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Button SFX/Button Press Normal");
        evt.start();
        evt.release();
    }
}