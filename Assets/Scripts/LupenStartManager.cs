using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LupenStartManager : MonoBehaviour
{
    public GameObject lupenMenu;
    public GameObject darkOverlay;
    public CameraFade cameraFade;
    public float aktivierungsDelay = 7.3f;

    void Start()
    {
        lupenMenu.SetActive(false); // Anfang: ausblenden
        darkOverlay.SetActive(false);
        StartCoroutine(StarteNachDelay());
    }

    IEnumerator StarteNachDelay()
    {
        yield return new WaitForSeconds(aktivierungsDelay);

        if (cameraFade != null)
            yield return cameraFade.FadeOut(); // Schwarzblende

        lupenMenu.SetActive(true); // Menü aktivieren
        if (darkOverlay != null)
            darkOverlay.SetActive(true);

        if (cameraFade != null)
        {
            yield return cameraFade.FadeIn(); // Wieder zurückblenden
        }
    }
}