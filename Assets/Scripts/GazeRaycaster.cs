using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeRaycaster : MonoBehaviour
{
    private GazeTrigger currentGazeTarget;
    private float maxDistance = 100f;

    void Update()
    {
        Camera cam = Camera.main;
        if (cam == null) return; // verhindert NullReferenceException

        Ray ray = Application.isEditor
            ? Camera.main.ScreenPointToRay(Input.mousePosition) //Fürs Testing in Game Mode
            : new Ray(Camera.main.transform.position, Camera.main.transform.forward); //Für die APK

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance))

        {
            GazeTrigger gazeTarget = hit.collider.GetComponent<GazeTrigger>();

            if (gazeTarget != null)
            {
                if (gazeTarget != currentGazeTarget)
                {
                    if (currentGazeTarget != null)
                        currentGazeTarget.EndGaze();

                    currentGazeTarget = gazeTarget;
                    currentGazeTarget.StartGaze();
                }

                Debug.Log("🎯 Gaze erkannt auf: " + gazeTarget.name);
            }
            else if (currentGazeTarget != null)
            {
                currentGazeTarget.EndGaze();
                currentGazeTarget = null;
            }
        }
        else if (currentGazeTarget != null)
        {
            currentGazeTarget.EndGaze();
            currentGazeTarget = null;
        }


    }
}    