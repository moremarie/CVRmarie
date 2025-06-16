using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTarget : MonoBehaviour
{
    public float gazeTime = 2f;
    private float gazeTimer = 0f;
    private bool isGazedAt = false;
    private bool hasSpoken = false;

    public GameObject WeltkugelObject; // Dein Sprite-Objekt

    void Update()
    {
        if (isGazedAt)
        {
            gazeTimer += Time.deltaTime;
            if (gazeTimer >= gazeTime && !hasSpoken)
            {
                hasSpoken = true;

                // Optional: Lehrer spricht starten
                Debug.Log("Lehrer spricht!");

                // Weltkugel (Sprite) ausblenden
                if (WeltkugelObject != null)
                    WeltkugelObject.SetActive(false);
            }
        }
        else
        {
            gazeTimer = 0f;
        }
    }

    public void SetGazedAt(bool gazed)
    {
        isGazedAt = gazed;
    }
}
