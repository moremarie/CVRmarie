using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIghtDimmer : MonoBehaviour
{
    public Light sceneLight;
    public float dimSpeed = 0.5f;
    public float targetIntensity = 0.4f;

    public void DimLight()
    {
        StartCoroutine(DimRoutine());
    }

    IEnumerator DimRoutine()
    {
        while (sceneLight.intensity > targetIntensity)
        {
            sceneLight.intensity -= Time.deltaTime * dimSpeed;
            yield return null;
        }
    }
}
