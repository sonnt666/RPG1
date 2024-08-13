using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerEquipWeapon : MonoBehaviour, IPointerClickHandler
{
    public enum Type
    {
        vukhi,
        mu,
        ao,
        nhan
    }

    public Type type;

    public Items item;
    public Image icon;

    public void Equip(Items x)
    {
        item = x;
        icon.sprite = item.itemsInfo.sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //show bảng thông tin trang bị
    }
}
