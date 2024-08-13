using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Canvas canvas;
    public CanvasGroup group;

    Vector3 pos;
    public Image plantImage;
    public GameObject plant;

    public void OnBeginDrag(PointerEventData eventData)
    {
        plantImage.gameObject.SetActive(true);
        pos = plantImage.rectTransform.anchoredPosition;
        group.alpha = 1f;
        group.blocksRaycasts = false;
        DragDropController.curentPlant = plant;
    }

    public void OnDrag(PointerEventData eventData)
    {
        plantImage.rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        group.alpha = .6f;
        group.blocksRaycasts = true;
        plantImage.gameObject.SetActive(false);
        plantImage.rectTransform.anchoredPosition = pos;
    }
}