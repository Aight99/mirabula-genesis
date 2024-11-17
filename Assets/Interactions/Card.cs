using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Card
    : MonoBehaviour,
        IDragHandler,
        IBeginDragHandler,
        IEndDragHandler,
        IPointerEnterHandler,
        IPointerExitHandler
{
    private GraphicRaycaster _canvasRaycaster;
    private Image _image;
    private Color _initialColor;

    [SerializeField]
    private Color selectionColor;
    private bool _isDragging = false;
    private Vector2 _dragOffset = Vector2.zero;

    public Transform basePointTransform;

    public void Awake()
    {
        _canvasRaycaster = GetComponentInParent<GraphicRaycaster>();
        _image = GetComponent<Image>();
        // _initialColor = _image.color;
        _image.color = Color.clear;
    }

    public void Update()
    {
        if (_isDragging)
        {
            // _image.color = selectionColor;

            var targetPosition = MousePosition;
            var positionWithTakeOffset = targetPosition - _dragOffset;
            transform.position = positionWithTakeOffset;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // _image.color = selectionColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // _image.color = _initialColor;
    }

    public void OnDrag(PointerEventData eventData) { }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _isDragging = true;
        _canvasRaycaster.enabled = false;
        _dragOffset = MousePosition - (Vector2)transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _isDragging = false;
        _canvasRaycaster.enabled = true;
        _dragOffset = Vector2.zero;
        // _image.color = _initialColor;
        PlaceToBase();
    }

    private Vector2 MousePosition => (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

    public void PlaceToBase()
    {
        if (basePointTransform != null)
        {
            transform.position = basePointTransform.position;
        }
    }
}
