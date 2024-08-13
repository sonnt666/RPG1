using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("DiemCaoNhat");
        print("Highscore: " + highscore);
    }

    // Update is called once per frame
    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.H)) 
        {
            score++;
            if(score > highscore)
            {
                highscore = score;
                PlayerPrefs.SetInt("DiemCaoNhat", highscore);
                print("Đã cập nhật :" +  highscore);
            }
        }
    }
}
