using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspektivenManager : MonoBehaviour //Code von ChatGPT
{
    public Camera kameraStart;
    public Camera kameraSchueler;
    public Camera kameraLehrer;
    public Camera kameraMedien;
    public Camera kameraManipuliert;

    public Animator schuelerAnimator;
    public GameObject schuelerUI;
    public AudioSource medienAudio;
    public AudioSource audioBenis;
    public AudioSource audioLehrer;
    public AudioSource audioMedien;
    public AudioSource audioManipuliert;
    public UnityEngine.Video.VideoPlayer handyVideoPlayer;

    public PerspektivenManager()
    {
    }

    public void AktiviereStart()
    {
        AllesDeaktivieren();
        kameraStart.enabled = true;

        SetAudioListener(kameraStart);

    }

    public void AktiviereSchueler()
    {
        AllesDeaktivieren();
        kameraSchueler.enabled = true;

        if (schuelerAnimator != null)
            schuelerAnimator.SetTrigger("Scrollen");

        if (schuelerUI != null)
            schuelerUI.SetActive(true);

        if (audioBenis != null)
        {
            Debug.Log("BenisAudio wird abgespielt"); // 👈 Debug-Zeile
            audioBenis.Play();
        }

        if (handyVideoPlayer != null)
        {
            handyVideoPlayer.Stop(); // Nur für Sicherheit, wenn schon läuft
            handyVideoPlayer.Play();
        }   

        SetAudioListener(kameraSchueler); 
    }

    public void AktiviereLehrer()
    {
        AllesDeaktivieren();
        kameraLehrer.enabled = true;

        SetAudioListener(kameraLehrer); 
    }

    public void AktiviereMedien()
    {
        AllesDeaktivieren();
        kameraMedien.enabled = true;

        if (medienAudio != null)
            medienAudio.Play();

        SetAudioListener(kameraMedien);     
    }

    public void AktiviereManipuliert()
    {
        AllesDeaktivieren();
        kameraManipuliert.enabled = true;

        SetAudioListener(kameraManipuliert); 
    }

    void AllesDeaktivieren()
    {
        kameraStart.enabled = false;
        kameraSchueler.enabled = false;
        kameraLehrer.enabled = false;
        kameraMedien.enabled = false;
        kameraManipuliert.enabled = false;

        if (schuelerUI != null)
            schuelerUI.SetActive(false);

        if (medienAudio != null)
            medienAudio.Stop();

        if (audioBenis != null) audioBenis.Stop();
        if (audioLehrer != null) audioLehrer.Stop();
        if (audioMedien != null) audioMedien.Stop();
        if (audioManipuliert != null) audioManipuliert.Stop();
    }
    void SetAudioListener(Camera zielkamera)
    {
    foreach (Camera cam in FindObjectsOfType<Camera>())
        {
            AudioListener listener = cam.GetComponent<AudioListener>();
            if (listener != null)
                Destroy(listener);
        }

        if (zielkamera != null && zielkamera.GetComponent<AudioListener>() == null)
        {
            zielkamera.gameObject.AddComponent<AudioListener>();
        }
    }
}