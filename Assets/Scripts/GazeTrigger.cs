using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;



public class GazeTrigger : MonoBehaviour //Code von ChatGPT
{
    public float gazeTime = 2f;
    public UnityEvent onGazeComplete;
    public ReticleGaze reticle;
    public VideoPlayer videoPlayer;
    public GameObject weltkugel;
    
    public AudioSource audioSource;

    private float timer = 0f;
    private bool isGazing = false;
    private bool hasTriggered = false;

    void Start()
    {
        if (weltkugel != null)
        {
            weltkugel.SetActive(true); // Weltkugel sicher aktivieren beim Start
            Debug.Log("🌍 Weltkugel wurde im Start aktiviert");
        }
    }

    void Update()
    {
        if (isGazing && !hasTriggered)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {
                hasTriggered = true;
                isGazing = false;
                timer = 0f;

                onGazeComplete.Invoke();

                if (videoPlayer != null && !videoPlayer.isPlaying)
                    videoPlayer.Play();

                if (audioSource != null && !audioSource.isPlaying)
                    audioSource.Play();

               
                if (weltkugel != null)
                    weltkugel.SetActive(false);
            }
        }
    }

    public void StartGaze()
    {
        isGazing = true;
        timer = 0f;

        Debug.Log("👁️ StartGaze wurde ausgelöst auf " + gameObject.name);

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
}