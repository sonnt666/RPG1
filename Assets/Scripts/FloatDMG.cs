using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class FloatDMG : MonoBehaviour
{
    public static FloatDMG instance;
    public List<SetShowDMG> showDmg;

    private void Start()
    {
        instance = this;

        foreach (Transform dmg in transform)
        {
            showDmg.Add(dmg.GetComponent<SetShowDMG>());
        }
    }

    public void Show(int dmg, Vector3 pos)
    {
        var getOne = showDmg.FirstOrDefault(x => !x.gameObject.activeSelf);
        if (getOne != null)
        {
            getOne.setDMG(dmg);
            getOne.transform.position = pos;
            getOne.gameObject.SetActive(true);
            StartCoroutine(delay(getOne.gameObject));
        }
    }

    IEnumerator delay(GameObject go)
    {
        yield return new WaitForSeconds(0.5f);
        go.SetActive(false);
    }
}