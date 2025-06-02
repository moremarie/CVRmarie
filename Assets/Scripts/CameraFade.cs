using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFade : MonoBehaviour
{
    public Image fadeImage;
    public float fadeTime = 1.5f;

    void Start()
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        Color color = fadeImage.color;
        float t = 0;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, t / fadeTime);
            fadeImage.color = color;
            yield return null;
        }

        fadeImage.raycastTarget = false; // Klicks durchlassen
    }

    public IEnumerator FadeIn()
    {
        Color color = fadeImage.color;
        fadeImage.raycastTarget = true;
        float t = 0;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, t / fadeTime);
            fadeImage.color = color;
            yield return null;
        }
    }
}    
