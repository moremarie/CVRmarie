using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleFollower : MonoBehaviour
{
    public float distanceFromCamera = 2f;

    void Update()
    {
        if (Camera.main != null)
        {
            Transform cam = Camera.main.transform;
            transform.position = cam.position + cam.forward * distanceFromCamera;
            transform.rotation = Quaternion.LookRotation(cam.forward);
        }
    }
}
