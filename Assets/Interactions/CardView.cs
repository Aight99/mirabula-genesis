using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField]
    private Card _model;

    [SerializeField]
    private Color _color;

    [SerializeField]
    private float _followSpeed = 30f;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.color = _color;
        _image.raycastTarget = false;
    }

    private void Update()
    {
        MoveToModel();
    }

    private void MoveToModel()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            _model.transform.position,
            _followSpeed * Time.deltaTime
        );
    }
}
