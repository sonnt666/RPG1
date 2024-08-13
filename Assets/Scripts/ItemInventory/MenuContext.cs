using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuContext : MonoBehaviour
{
    public PlayerEquipWeapon playerEquipVK;
    public PlayerEquipWeapon playerEquipMu;
    public PlayerEquipWeapon playerEquipAo;
    public PlayerEquipWeapon playerEquipNhan;

    public InventoryPanel inventoryPanel;

    public static MenuContext instance;
    public GameObject mainBoard;
    public Items item;

    public Image icon;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    private void Awake()
    {
        instance = this;
    }

    public void Show(Items x)
    {
        item = x;
        icon.sprite = item.itemsInfo.sprite;
        nameText.text = item.itemsInfo.name;
        descriptionText.text = item.itemsInfo.description;
        mainBoard.SetActive(true);
    }

    public void EquipBtn()
    {
        switch (item.itemsInfo.type)
        {
            case 1:
                {
                    if (playerEquipVK.item.itemsInfo.id == 0)
                    {
                        playerEquipVK.Equip(item);
                        ListAllItems.Instance.listPlayerItems.Remove(item);
                        inventoryPanel.ClearSlot();
                        inventoryPanel.ShowItem();
                        CancelBtn();
                    }
                    else
                    {
                        ListAllItems.Instance.listPlayerItems.Add(playerEquipVK.item);
                        playerEquipVK.Equip(item);
                        ListAllItems.Instance.listPlayerItems.Remove(item);
                        inventoryPanel.ClearSlot();
                        inventoryPanel.ShowItem();
                        CancelBtn();
                    }
                }
                break;

            case 2:
                {
                    playerEquipMu.Equip(item);
                    ListAllItems.Instance.listPlayerItems.Remove(item);
                    inventoryPanel.ClearSlot();
                    inventoryPanel.ShowItem();
                    CancelBtn();
                }
                break;

            case 3:
                {
                    playerEquipAo.Equip(item);
                    ListAllItems.Instance.listPlayerItems.Remove(item);
                    inventoryPanel.ClearSlot();
                    inventoryPanel.ShowItem();
                    CancelBtn();
                }
                break;

            case 4:
                {
                    playerEquipNhan.Equip(item);
                    ListAllItems.Instance.listPlayerItems.Remove(item);
                    inventoryPanel.ClearSlot();
                    inventoryPanel.ShowItem();
                    CancelBtn();
                }
                break;
        }
    }

    public void CancelBtn()
    {
        item = null;
        mainBoard.SetActive(false);
    }
}