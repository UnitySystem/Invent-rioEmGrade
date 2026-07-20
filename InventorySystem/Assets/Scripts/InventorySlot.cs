using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData != null && eventData.pointerDrag != null)
        {
            DraggebleObjectUI draggable = eventData.pointerDrag.GetComponent<DraggebleObjectUI>();

            if (draggable != null)
            {
                draggable.ParentReturnTo = transform;
            }
        }
    }
}