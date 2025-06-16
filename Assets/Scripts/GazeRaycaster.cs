using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeRaycaster : MonoBehaviour
{
    
    private GazeTrigger currentGazeTarget;
    private float maxDistance = 100f;

    public ReticleGaze reticleGaze;

    void Update()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        Ray ray = Application.isEditor
            ? cam.ScreenPointToRay(Input.mousePosition)
            : new Ray(cam.transform.position, cam.transform.forward);

        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red);

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

                if (reticleGaze != null)
                    reticleGaze.SetGazing(true);
            }
            else if (currentGazeTarget != null)
            {
                currentGazeTarget.EndGaze();
                currentGazeTarget = null;

                if (reticleGaze != null)
                    reticleGaze.SetGazing(false);
            }
        }
        else if (currentGazeTarget != null)
        {
            currentGazeTarget.EndGaze();
            currentGazeTarget = null;

            if (reticleGaze != null)
                reticleGaze.SetGazing(false);
        }
    }
}