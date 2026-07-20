using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggebleObjectUI : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Canvas _canvas;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Transform _parentReturnTo = null;

    public Transform ParentReturnTo
    {
        get => _parentReturnTo;
        set => _parentReturnTo = value;
    }

    private void Start()
    {
        _canvas = FindAnyObjectByType<Canvas>();
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _parentReturnTo = transform.parent;

        _canvasGroup.blocksRaycasts = false;

        transform.SetParent(_canvas.transform);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;

        transform.SetParent(_parentReturnTo);
        _rectTransform.anchoredPosition = Vector2.zero;
    }
}