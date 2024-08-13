using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseHover : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public GameObject BangThongTin;

    public void OnPointerEnter(PointerEventData eventData)
    {
        BangThongTin.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        BangThongTin.SetActive(false);
    }
}
