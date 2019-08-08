using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class QualityDropdown : UIDropdown<string>
{

    private void Start()
    {
        Initialise(new List<string>(QualitySettings.names));
    }

    public override int Select()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        return dropdown.value;
    }
}
