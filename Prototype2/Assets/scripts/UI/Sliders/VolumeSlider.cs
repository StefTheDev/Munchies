using UnityEngine.Audio;

public class VolumeSlider : UISlider<AudioMixer>
{
    public AudioMixer audioMixer;

    public override void Select()
    {
        audioMixer.SetFloat("SettingsVolume", slider.value);
    }
}
