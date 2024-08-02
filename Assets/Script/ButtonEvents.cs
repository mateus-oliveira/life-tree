using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private AudioSource soundHover;

    public void OnPointerEnter(PointerEventData eventData)
    {
        soundHover.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //nothing
    }
}
