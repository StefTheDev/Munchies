using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMaster : MonoBehaviour
{
    //Scaling Environment
    [Range(0.0f, 1.0f)]
    public float environScale = 0.0f;

    public GameObject prop1;

    //Lighting
    public Light thisLight;

    [Range(0.0f, 10.0f)]
    public float intenseVal = 0.0f;

    [Range(0.0f, 1.0f)]
    public float lightR = 0.0f;

    [Range(0.0f, 1.0f)]
    public float lightG = 0.0f;

    [Range(0.0f, 1.0f)]
    public float lightB = 0.0f;

    Color lightCol;

    // Start is called before the first frame update
    void Start()
    {
        thisLight = thisLight.GetComponent<Light>();
        lightR = 1.0f;
        lightG = 1.0f;
        lightB = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        prop1.transform.localScale = new Vector3(environScale, environScale, environScale);

        thisLight.intensity = intenseVal;

        lightCol = new Vector4(lightR, lightG, lightB, thisLight.color.a);

        thisLight.color = lightCol;
    }
}