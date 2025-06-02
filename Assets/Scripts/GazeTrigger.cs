using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class GazeTrigger : MonoBehaviour //Code von ChatGPT
{
    public float gazeTime = 2f; // Sekunden bis Aktivierung
    public UnityEvent onGazeComplete;

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
                timer = 0f;
                isGazing = false;
            }
        }
    }

    public void StartGaze()
    {
        isGazing = true;
        timer = 0f;
    }

    public void EndGaze()
    {
        isGazing = false;
        timer = 0f;
    }
}
