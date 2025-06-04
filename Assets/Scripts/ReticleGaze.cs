using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleGaze : MonoBehaviour
{
    public float gazeGrowSpeed = 2f;
    public float maxScale = 1.5f;
    public float normalScale = 1f;

    public Color normalColor = Color.white;
    public Color gazeColor = Color.cyan;

    private RectTransform rt;
    private Image image;
    private bool isGazing;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        rt.localScale = Vector3.one * normalScale;
        if (image != null)
            image.color = normalColor;
    }

    void Update()
    {
        float targetScale = isGazing ? maxScale : normalScale;
        rt.localScale = Vector3.Lerp(rt.localScale, Vector3.one * targetScale, Time.deltaTime * gazeGrowSpeed);

        if (image != null)
            image.color = Color.Lerp(image.color, isGazing ? gazeColor : normalColor, Time.deltaTime * gazeGrowSpeed);
    }

    public void SetGazing(bool active)
    {
        isGazing = active;
    }
}