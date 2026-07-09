using UnityEngine;
using UnityEngine.EventSystems;

public class DraggebleObject : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform _rectTransform;
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) 
        {
            _rectTransform.position = eventData.position;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
