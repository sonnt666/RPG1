using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetShowDMG : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void setDMG(int dmg)
    {
        text.text = "-" + dmg.ToString("n0");
    }
}
