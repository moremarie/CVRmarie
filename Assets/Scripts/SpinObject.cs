using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
 
{
    public Vector3 rotationSpeed = new Vector3(0, 90, 0); // Rotation in Grad/Sekunde

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
