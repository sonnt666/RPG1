using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Conversations : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI textContent;
    public GameObject playerAvatar;
    public GameObject NPCAvatar;
    public QuestPanel questPanel;

    public List<HoiThoai> listHT;
    public int current = 0;
    public int brandStoryID; //nhánh truyện

    public void LoadTextAsset(string path)
    {
        TextAsset loadText = Resources.Load<TextAsset>(path); //Đọc file textAsset
        string[] lines = loadText.text.Split('\n'); //cắt dòng -> mỗi dòng là 1 phần tử

        listHT = new List<HoiThoai>();
        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split("\t"); //cắt tab -> mỗi tab 1 phần tử

            HoiThoai ht = new HoiThoai(); //tạo 1 hội thoại mới và gán các cột vào thuộc tính tương ứng
            ht.id = System.Convert.ToInt32(cols[0]);
            ht.character = cols[1];
            ht.content = cols[2];

            listHT.Add(ht); //Thêm hội thoại vào danh sách hội thoại
        }

        current = 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        current++;
        NoiChuyen();
    }

    public void NoiChuyen()
    {
        if (current < listHT.Count)
        {
            if (listHT[current].character == "Player")
            {
                playerAvatar.SetActive(true);
                NPCAvatar.SetActive(false);
            }
            else
            {
                playerAvatar.SetActive(false);
                NPCAvatar.SetActive(true);
            }

            textContent.text = listHT[current].content;
        }
        else
        {
            QuestManager.instance.SetQipStory(brandStoryID); //tang len 1
            var getQ = QuestManager.instance.GetQuest(brandStoryID);
            if (getQ != null)
            {
                questPanel.ShowQuest(getQ, brandStoryID);
                questPanel.gameObject.SetActive(true);
            }
            gameObject.SetActive(false); //tắt giao diện nói chuyện đi
        }
    }

    public void SetAvatar(Sprite playerAvatar, Sprite nAvatar)
    {
        playerAvatar.GetComponent<Image>().sprite = playerAvatar;
        NPCAvatar.GetComponent<Image>().sprite = nAvatar;
    }
}

[System.Serializable]
public class HoiThoai
{
    public int id;
    public string character;
    public string content;
}