using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {

	Renderer rend;

	[Range(0.0f, 1.0f)]
	public float blendVal = 0.0f;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();

		rend.material.shader = Shader.Find("Custom/Blending");
	}

	// Update is called once per frame
	void Update () {
		//  blendVal = Mathf.PingPong(Time.time, 1.0f);

		rend.material.SetFloat("_Blend", blendVal);
	}
}
