using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LupenUebergang : MonoBehaviour
{
    public CameraFade fade;
    public PerspektivenManager perspektivenManager;
    public GameObject lupenMenu; // wird deaktiviert nach Wahl
     public GameObject darkOverlay;

    // Methoden für jede Perspektive
    public void AktiviereLehrerPerspektive() => StartCoroutine(WechselRoutine("Lehrer"));
    public void AktiviereSchuelerPerspektive()  => StartCoroutine(WechselRoutine("Schueler"));
    public void AktiviereMedienPerspektive()    => StartCoroutine(WechselRoutine("Medien"));
    public void AktiviereManipuliertPerspektive() => StartCoroutine(WechselRoutine("Manipuliert"));

    IEnumerator WechselRoutine(string perspektive)
    {
        yield return StartCoroutine(fade.FadeIn());

        if (lupenMenu != null)
            lupenMenu.SetActive(false);

        if (darkOverlay != null)
            darkOverlay.SetActive(false);    

        // Alle Kameras deaktivieren
        perspektivenManager.kameraStart.enabled = false;
        perspektivenManager.kameraSchueler.enabled = false;
        perspektivenManager.kameraLehrer.enabled = false;
        perspektivenManager.kameraMedien.enabled = false;
        perspektivenManager.kameraManipuliert.enabled = false;

        // Perspektive aktivieren + MainCamera-Tag setzen
        switch (perspektive)
        {
            case "Lehrer":
                perspektivenManager.kameraLehrer.enabled = true;
                SetActiveMainCamera(perspektivenManager.kameraLehrer);
                if (perspektivenManager.audioLehrer != null)
                    perspektivenManager.audioLehrer.Play();
                break;

            case "Schueler":
                perspektivenManager.kameraSchueler.enabled = true;
                SetActiveMainCamera(perspektivenManager.kameraSchueler);
                if (perspektivenManager.audioBenis != null)
                {
                    perspektivenManager.audioBenis.Play();
                    Debug.Log("Audio Benis über LupenUebergang gestartet");
                }
                break;

            case "Medien":
                perspektivenManager.kameraMedien.enabled = true;
                SetActiveMainCamera(perspektivenManager.kameraMedien);
                if (perspektivenManager.audioMedien != null)
                    perspektivenManager.audioMedien.Play();
                break;

            case "Manipuliert":
                perspektivenManager.kameraManipuliert.enabled = true;
                SetActiveMainCamera(perspektivenManager.kameraManipuliert);
                if (perspektivenManager.audioManipuliert != null)
                    perspektivenManager.audioManipuliert.Play();
                break;
        }

        yield return StartCoroutine(fade.FadeOut());
    }

    void SetActiveMainCamera(Camera neueHauptkamera)
    {
        foreach (Camera cam in FindObjectsOfType<Camera>())
        {
            if (cam.CompareTag("MainCamera"))
                cam.tag = "Untagged";
        }

        neueHauptkamera.tag = "MainCamera";
    }
}