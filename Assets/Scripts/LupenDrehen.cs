using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LupenDrehen : MonoBehaviour //Code von ChatGPT
{
    public float drehSpeed = 20f;

    void Update()
    {
        transform.Rotate(Vector3.up * drehSpeed * Time.deltaTime);
    }
    
}
