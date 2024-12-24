using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class playButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button Button;
    private Vector3 Default_Scale;
    public Vector3 Target_Scale;

    private void Start()
    {
        Default_Scale = transform.localScale;
    }
    public void IncreaseScale(Button button)
    {
        button.transform.localScale = Target_Scale;
    }
    public void Defaultscale(Button button)
    {
        button.transform.localScale = Default_Scale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        IncreaseScale(Button);
        Debug.Log("Hover");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Defaultscale(Button);
    }
}

