using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class UIDropdown<T> : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    private List<T> list;
    private int previousIndex = 0;

    private void Start()
    {
        dropdown.onValueChanged.AddListener(delegate { Select(); });
    }

    private void FixedUpdate()
    {
        if (previousIndex == dropdown.value) return;
        previousIndex = Select();
    }

    public void Initialise(List<T> list)
    {
        this.list = list;
        List<string> strings = new List<string>(); 

        list.ForEach(s => strings.Add(s.ToString()));

        dropdown.AddOptions(strings);
        dropdown.RefreshShownValue();
    }

    public T GetElement(int i)
    {
        return list[i];
    }

    public abstract int Select();
}
