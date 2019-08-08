using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIToggle : MonoBehaviour
{
    public Toggle toggle;

    private void Start()
    {
        toggle.onValueChanged.AddListener(delegate { Select(); });
    }

    public abstract void Select();
}
