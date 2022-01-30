using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX: MonoBehaviour
{
    void Start(){}
    
    public void onButtonHover()
    {
        FMOD.Studio.EventInstance evt;
        evt = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Button SFX/Button Hover");
        evt.start();
        evt.release();
    }
    
    public void onButtonPressNormal()
    {
        FMOD.Studio.EventInstance evt;
        evt = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Button SFX/Button Press Normal");
        evt.start();
        evt.release();
    }
    
    public void onButtonPressBig()
    {
        FMOD.Studio.EventInstance evt;
        evt = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Button SFX/Button Press Big");
        evt.start();
        evt.release();
    }
}
