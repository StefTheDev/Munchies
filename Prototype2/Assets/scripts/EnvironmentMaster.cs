using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMaster : MonoBehaviour
{
    // Singleton
    private static EnvironmentMaster instance;

    public static EnvironmentMaster Instance { get { return instance; } }

    public GameObject[] props;

    public ChangeMaterial groundTexture;

    private Animator environmentAnimator;

    //Lighting
    public Light[] lights;

    public float finalScale = 1.0f;
    public float finalIntensity = 10.0f;

    public float environmentFactor = 0.0f;
    private bool updateEnvironment = true;

    private void Awake()
    {
        // Singleton
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        environmentAnimator = GetComponent<Animator>();

        UpdateEnvironment();
    }

    private void Update()
    {
        if (!updateEnvironment) { return; }

        UpdateEnvironment();
    }


    public void UpdateEnvironment()
    {
        var newScale = environmentFactor * finalScale;
        foreach (GameObject prop in props)
        {
            prop.transform.localScale = new Vector3(newScale, newScale, newScale);
        }

        var newIntensity = environmentFactor * finalIntensity;
        foreach (Light light in lights)
        {
            light.intensity = newIntensity;
        }

        groundTexture.blendVal = environmentFactor;
    }

    public void SetStarNumber(int starNum)
    {
        // environmentFactor = ((float)starNum / 5);
        environmentAnimator.SetTrigger(starNum.ToString());
    }
}