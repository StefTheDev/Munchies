using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Settings : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Slider volumeSlider;
    public TMP_Dropdown qualityDropdown, resolutionDropdown;

    private Resolution[] resolutions;

    public void Start()
    {
        this.resolutions = Screen.resolutions;
        List<string> resolutions = new List<string>();
        resolutionDropdown.ClearOptions();

        int index = 0;

        for (int i = 0; i < this.resolutions.Length; i++)
        {
            Resolution resolution = this.resolutions[i];
            resolutions.Add(resolution.width + " x " + resolution.height + " - " + resolution.refreshRate + "hz");

            if (resolution.width == Screen.currentResolution.width && 
                resolution.height == Screen.currentResolution.height && 
                resolution.refreshRate == Screen.currentResolution.refreshRate)
            {
                index = i;
            }
        }

        resolutionDropdown.AddOptions(resolutions);
        resolutionDropdown.value = index;
        resolutionDropdown.RefreshShownValue();
    }

    private void Update()
    {
        audioMixer.SetFloat("SettingsVolume", volumeSlider.value);

        Screen.SetResolution(
            resolutions[resolutionDropdown.value].width,
            resolutions[resolutionDropdown.value].height, 
            Screen.fullScreen,
            resolutions[resolutionDropdown.value].refreshRate
        );
    }
}
