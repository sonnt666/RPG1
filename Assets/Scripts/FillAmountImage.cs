using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillAmountImage : MonoBehaviour
{
    public Image ringbackground;
    public Image icon;
    public TextMeshProUGUI countdowntext;
    public Button skillButton;

    public float countdownTime;

    // Start is called before the first frame update
    void Start()
    {
        countdownTime = 0;
    }

    // Update is called once per frame
    void Update()
    {  
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            countdowntext.text = countdownTime.ToString("n0");
            ringbackground.fillAmount = 1 - (countdownTime / 10);
            skillButton.interactable = false;
            icon.color = new Color(.5f, .5f, .5f, 1);
        }
        else
        {
            countdowntext.gameObject.SetActive(false);
            skillButton.interactable = true;
            icon.color = new Color(1, 1, 1, 1);
        }
    }

    public void gameButton()
    {
        countdownTime = 10f;
        countdowntext.gameObject.SetActive(true);
    }
}
