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

    public PerspektivenManager()
    {
    }

    public void AktiviereStart()
    {
        AllesDeaktivieren();
        kameraStart.enabled = true;
    }

    public void AktiviereSchueler()
    {
        AllesDeaktivieren();
        kameraSchueler.enabled = true;

        if (schuelerAnimator != null)
            schuelerAnimator.SetTrigger("Scrollen");

        if (schuelerUI != null)
            schuelerUI.SetActive(true);
    }

    public void AktiviereLehrer()
    {
        AllesDeaktivieren();
        kameraLehrer.enabled = true;
    }

    public void AktiviereMedien()
    {
        AllesDeaktivieren();
        kameraMedien.enabled = true;

        if (medienAudio != null)
            medienAudio.Play();
    }

    public void AktiviereManipuliert()
    {
        AllesDeaktivieren();
        kameraManipuliert.enabled = true;
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
    }
}