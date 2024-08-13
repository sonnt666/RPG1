using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoxNPC : MonoBehaviour
{
    public Transform player;
    public Conversations conversationPanel;
    public int brandid = 2; //fox story

    private void Start()
    {
        brandid = 2;
    }

    private void OnMouseDown()
    {
        if (Vector2.Distance(transform.position, player.position) < 2f)
        {
            int qip = QuestManager.instance.GetQipStory(brandid);
            switch (qip)
            {
                case 0:
                    {
                        conversationPanel.gameObject.SetActive(true);
                        conversationPanel.LoadTextAsset("Map1/fox1");
                        conversationPanel.brandStoryID = brandid;
                        conversationPanel.NoiChuyen();
                    }
                    break;

                case 1:
                    {
                        conversationPanel.gameObject.SetActive(true);
                        conversationPanel.LoadTextAsset("Map1/fox2");
                        conversationPanel.brandStoryID = 0; //Không thay đổi tiến trình, chỉ thay đổi khi làm nhiệm vụ
                        conversationPanel.NoiChuyen();
                    }
                    break;
                case 2:
                    {
                        conversationPanel.gameObject.SetActive(true);
                        conversationPanel.LoadTextAsset("Map1/fox3");
                        conversationPanel.brandStoryID = brandid;
                        conversationPanel.NoiChuyen();
                    }
                    break;
            }
        }
    } 
}