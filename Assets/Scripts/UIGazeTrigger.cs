using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GazeTriggerUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float gazeTime = 2f;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        isGazing = true;
        timer = 0f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isGazing = false;
        timer = 0f;
    }
}