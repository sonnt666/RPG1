using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildPosition : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;
    public GameObject slot;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (slot != null)
        {
            Debug.Log("Vị trí này đã có Plant khác đứng rồi, chọn cái khác nhé");
        }
        else
        {
            if (eventData.pointerDrag != null)
            {
                slot = Instantiate(DragDropController.curentPlant, transform.position, Quaternion.identity);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(1f, 0, 0, .5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(1f, 0, 0, 0);
    }
}