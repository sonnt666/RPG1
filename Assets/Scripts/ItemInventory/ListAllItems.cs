using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListAllItems : MonoBehaviour
{
    public static ListAllItems Instance;

    public List<Sprite> allSprite;
    public List<ItemsInfo> allItems;
    public List<Items> listPlayerItems;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        TextAsset load =  Resources.Load<TextAsset>("allItem");
        string[] lines = load.text.Split('\n');

        allItems = new List<ItemsInfo>();
        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split('\t');

            ItemsInfo x = new ItemsInfo();
            x.id = i;
            x.name = cols[1];
            x.description = cols[2];
            x.sprite = allSprite[i - 1];
            x.type = Convert.ToInt32(cols[4]);
            x.rare = Convert.ToInt32(cols[5]);

            allItems.Add(x);
        }

        //giả sử cho nhân vật sở hữu toàn bộ item
        foreach (var x in allItems)
        {
            Items i = new Items();
            i.itemsInfo = x;

            listPlayerItems.Add(i);
        }
    }
}

[System.Serializable]
public class Items
{
    public ItemsInfo itemsInfo;
    public thuocTinhTrangBi att1;
    public thuocTinhTrangBi att2;
    public thuocTinhTrangBi att3;
}

[System.Serializable]
public class ItemsInfo
{
    public int id;
    public string name;
    public string description;
    public Sprite sprite;
    public int type; //1 - vk, 2 - ...
    public int rare; //độ hiếm
}

[System.Serializable]
public class thuocTinhTrangBi
{
    public int id; //1 - str, 2 - agi..
    public string name; //tên thuộc tính
    public int value; //giá trị
    public int type; //loại: 1 + %, 2 + điểm
}
