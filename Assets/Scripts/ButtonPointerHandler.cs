using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Valve.VR.Extras;

public class ButtonPointerHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent click;
    public void OnPointerClick(PointerEventData eventData)
    {
        print("click");
        click.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("up");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("exit");
    }
}
