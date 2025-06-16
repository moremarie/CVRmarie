using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeReactor : MonoBehaviour
{
    private GazeTrigger gazeTrigger;

    void Start()
    {
        gazeTrigger = GetComponent<GazeTrigger>();
    }

    void OnPointerEnter()
    {
        if (gazeTrigger != null)
            gazeTrigger.StartGaze();
    }

    void OnPointerExit()
    {
        if (gazeTrigger != null)
            gazeTrigger.EndGaze();
    }
}
