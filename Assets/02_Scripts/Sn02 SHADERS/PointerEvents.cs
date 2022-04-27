using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public bool gaze;//f
    private MeshRenderer meshRenderer = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnPointerEnter(PointerEventData eventData)//OnPointerStay NO FUNCIONA
    {
        GetComponent<MeshRenderer>().enabled = true;

        print("GAZE GUIA?");
        gaze = true;
        print("GAZETRUE");
        SoundManagerGuia.instance.PlayInstruccion04();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("Exit");////
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //print("Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //print("Up");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //OnClick.Invoke();
        //print("Click");
    }
}
