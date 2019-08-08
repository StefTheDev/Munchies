using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBeltScroll : MonoBehaviour
{
	[SerializeField]
	float scrollX;

	[SerializeField]
	float scrollY;

	private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
		rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
		float osX = scrollX * Time.time;
		float osY = scrollY * Time.time;
		rend.material.mainTextureOffset = new Vector2(osX, osY);
    }
}
