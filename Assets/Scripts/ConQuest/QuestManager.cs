using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<BrandStoryID> brandStory = new List<BrandStoryID>();
    public List<Quest> AllQuests = new List<Quest>(); //tat ca nhiem vu trong game
    public List<Quest> receivedQuest = new List<Quest>(); //nhiem vu nguoi choi da nhan (chua lam xong)

    private void Awake()
    {
        if (instance != null && instance != this) //Nếu instance đã tồn tại và instance không tham chiếu tới đối tượng này
        {
            DestroyImmediate(this); //xóa đối tượng này ngay lập tức
        }
        else //nếu instance rỗng
        {
            instance = this; //gán đối tượng này vào instance
            DontDestroyOnLoad(gameObject); //Không xóa khi chuyển scene
        }
    }

    private void Start()
    {
        LoadTextAsset("Map1/subQuest");
        brandStory.Add(new BrandStoryID { brandID = 1, name = "mainStory", qip = 0 });
        brandStory.Add(new BrandStoryID { brandID = 2, name = "foxStory", qip = 0 });
    }

    public void LoadTextAsset(string path)
    {
        TextAsset loadText = Resources.Load<TextAsset>(path); //Đọc file textAsset
        string[] lines = loadText.text.Split('\n'); //cắt dòng -> mỗi dòng là 1 phần tử

        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split("\t"); //cắt tab -> mỗi tab 1 phần tử

            Quest q = new Quest();
            q.brandStoryID = System.Convert.ToInt32(cols[0]);
            q.qip = System.Convert.ToInt32(cols[1]);
            q.name = cols[2];
            q.description = cols[3];
            q.xpReward = System.Convert.ToInt32(cols[4]);
            q.coinReward = System.Convert.ToInt32(cols[5]);
            q.require = System.Convert.ToInt32(cols[6]);

            AllQuests.Add(q); //Thêm hội thoại vào danh sách hội thoại
        }
    }

    public Quest GetQuest(int id)
    {
        var qip = GetQipStory(id);
        var getQ = AllQuests.FirstOrDefault(x => x.brandStoryID == id && x.qip == qip);
        if (getQ != null)
        {
            return getQ;
        }
        else
        {
            return null;
        }
    }

    public int GetQipStory(int id)
    {
        var getQip = brandStory.FirstOrDefault(x => x.brandID == id);
        if (getQip != null)
        {
            return getQip.qip;
        }
        else
        {
            return 0;
        }
    }

    public void SetQipStory(int id)
    {
        var getQip = brandStory.FirstOrDefault(x => x.brandID == id);
        if (getQip != null)
        {
            getQip.qip++; //tiến trình + 1
        }
    }

    public void BackQip(int id)
    {
        var getQip = brandStory.FirstOrDefault(x => x.brandID == id);
        if (getQip != null)
        {
            getQip.qip--; //tiến trình - 1
        }
    }
}

[System.Serializable]
public class BrandStoryID
{
    public int brandID;
    public string name;
    public int qip; //quest in progress
}

[System.Serializable]
public class Quest
{
    public int brandStoryID; //vd: 2 -> foxStory
    public int qip; //quest in progress //vd: => 1
    public string name;
    public string description; //mo ta nhiem vu
    public int xpReward; //phan thuong kinh nghiem
    public int coinReward; //phan thuong coin
    public int require; //yeu cau nhiem vu
    public int current;
    public bool complete;

    public void SetCurrent()
    {
        current++;
        if (current >= require)
        {
            complete = true;
        }
    }
}