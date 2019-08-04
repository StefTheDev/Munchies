using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenToggle : UIToggle
{
    public override void Select()
    {
        Screen.fullScreen = toggle.isOn;
    }
}
