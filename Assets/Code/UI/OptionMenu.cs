using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
public Canvas Option ;
public bool optionactive = false ;
public void popup() {
    if (optionactive == false) {
        optionactive = true ;
        Option.enabled = true ;
    }
    else if (optionactive == true) {
        optionactive = false ;
        Option.enabled = false ;
    }
}
}
