using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour, IPointerClickHandler, IPointerUpHandler
{
    public Items item;
    public Image icon;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
        {
            MenuContext.instance.Show(item);
            MenuContext.instance.gameObject.SetActive(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void SetIcon()
    {
        if (item != null)
        {
            icon.sprite = item.itemsInfo.sprite;
        }
        else
        {
            icon.sprite = null;
        }
    }
}