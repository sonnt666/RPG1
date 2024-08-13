using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class QuestPanel : MonoBehaviour
{
    public Quest quest;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI requimentText;
    public TextMeshProUGUI cointText;
    public TextMeshProUGUI expText;
    public int brandID;

    public void ShowQuest(Quest q, int id)
    {
        quest = q;
        title.text = quest.name;
        description.text = quest.description;
        requimentText.text = "Requiment: 0/" + quest.require.ToString();
        cointText.text = quest.coinReward.ToString();
        expText.text = quest.xpReward.ToString();
        brandID = id;
    }

    public void OKButton()
    {
        QuestManager.instance.receivedQuest.Add(quest);
        gameObject.SetActive(false);
    }

    public void CancelButton()
    {
        QuestManager.instance.BackQip(brandID);
        gameObject.SetActive(false);
    }
}
