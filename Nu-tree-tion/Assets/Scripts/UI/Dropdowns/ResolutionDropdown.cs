using System.Collections.Generic;
using UnityEngine;

public class ResolutionDropdown : UIDropdown<Resolution>
{
    private void Start()
    {
        Initialise(new List<Resolution>(Screen.resolutions));
    }


    public override int Select()
    {
        Resolution resolution = GetElement(dropdown.value);
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen, resolution.refreshRate);
        return dropdown.value;
    }
}