using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;



public class GazeTrigger : MonoBehaviour //Code von ChatGPT
{
    public float gazeTime = 2f; // Sekunden bis Aktivierung
    public UnityEvent onGazeComplete;
    public ReticleGaze reticle;
    public VideoPlayer videoPlayer;
    public GameObject weltkugel;

    private float timer = 0f;
    private bool isGazing = false;



    void Update()
    {
        if (isGazing)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {
                onGazeComplete.Invoke();

                if (videoPlayer != null && !videoPlayer.isPlaying)
                {
                    videoPlayer.Play();
                }

                timer = 0f;
                isGazing = false;
            }
        }
    }

    public void StartGaze()
    {
        isGazing = true;
        timer = 0f;

        if (reticle != null)
            reticle.SetGazing(true);
    }

    public void EndGaze()
    {
        isGazing = false;
        timer = 0f;

        if (reticle != null)
            reticle.SetGazing(false);
    }

    public void OnGazeComplete()
    {
        if (videoPlayer != null && !videoPlayer.isPlaying)
        {
            videoPlayer.Play();

            if (weltkugel != null)
                weltkugel.SetActive(false); // Weltkugel ausblenden, sobald Video startet
        }
    }    
}
