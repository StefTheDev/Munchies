using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessingCamera : MonoBehaviour
{
    [SerializeField]
    private Material ppMAT;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, ppMAT);
    }
}
