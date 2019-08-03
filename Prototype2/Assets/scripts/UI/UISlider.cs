using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class UISlider<T> : MonoBehaviour
{
    public Slider slider;
    public TMP_Text text;

    private void Start()
    {
                UpdatePercentage();

        slider.onValueChanged.AddListener(delegate {
            UpdatePercentage();
            Select();
        });
    }

    public void UpdatePercentage()
    {
        float percentage = ((slider.value - slider.minValue) * 100) / (slider.maxValue - slider.minValue);
        text.SetText((int)percentage + "%");
    }

    public abstract void Select();
}
