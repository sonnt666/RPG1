using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health;
    public Slider healthBar;

    // Start is called before the first frame update
    private void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    public void GetDmg(int dmg)
    {
        health -= dmg;
        healthBar.value = health;
        if (health <= 0)
        {
            //Play animation dead
            //StartCoroutine()....
            Destroy(gameObject);
        }
    }
}