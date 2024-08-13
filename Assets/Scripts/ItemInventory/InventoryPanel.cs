using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public ListAllItems ListAllItems;
    public Transform slotParent;
    public List<SlotItem> listSlots;

    private void Start()
    {
        foreach (Transform t in slotParent)
        {
            listSlots.Add(t.GetComponent<SlotItem>());
        }

        ShowItem();
    }

    public void ShowItem()
    {
        for (int i = 0; i < ListAllItems.listPlayerItems.Count; i++)
        {
            listSlots[i].item = ListAllItems.listPlayerItems[i];
            listSlots[i].SetIcon();
        }
    }

    public void ClearSlot()
    {
        foreach(var t in listSlots)
        {
            t.item = null;
            t.SetIcon();
        }
    }
}