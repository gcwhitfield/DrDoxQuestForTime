using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class InvertColorPostProcessEffect : MonoBehaviour
{
    public Material colorInversionMaterial;
    public float interpolationAmt;
    public float intensity;
    public AnimationCurve effectCurve;
    [Range(0.1f, 5)]
    public float effectLength;

    public void PlayEffect()
    {
        StartCoroutine("DoPlayEffect");
    }

    IEnumerator DoPlayEffect()
    {
        Debug.Log("kasjdh");
        float t = 0;
        while (t < effectLength)
        {
            t += Time.deltaTime;
            interpolationAmt = t/effectLength;
            yield return null;
        }
    }


    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        colorInversionMaterial.SetFloat("_InterpolationAmt", interpolationAmt);
        colorInversionMaterial.SetFloat("_Intensity", intensity);
        Graphics.Blit(source, destination, colorInversionMaterial);
    }
}
