using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTowerData : MonoBehaviour
{
    public List<Tower> listTower;

    private void Awake()
    {
        TextAsset loadText = Resources.Load<TextAsset>("towerdata");
        string[] lines = loadText.text.Split('\n');
        
        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split('\t');

            Tower t = new Tower();
            t.id = Convert.ToInt32(cols[0]);
            t.towerName = cols[1];
            t.level = Convert.ToInt32(cols[2]);
            t.atk = Convert.ToInt32(cols[3]);
            t.range = Convert.ToInt32(cols[4]);
            t.atkSpeed = Convert.ToInt32(cols[5]);
            t.effect = cols[6];
            t.ratio = Convert.ToInt32(cols[7]);
            t.description = cols[8];
            t.cost = Convert.ToInt32(cols[9]);

            listTower.Add(t);
        }        
    }
}

[System.Serializable]
public class Tower
{
    public int id;
    public string towerName;
    public int level;
    public int atk;
    public int range;
    public int atkSpeed;
    public string effect;
    public int ratio;
    public string description;
    public int cost;
}