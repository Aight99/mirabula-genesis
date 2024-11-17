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

    // [SerializeField]
    // private float _tiltSpeed = 80f;

    // [SerializeField]
    // private float _tiltAmount = 50f;

    // [SerializeField]
    // private float _rotationAmount = 50f;

    private Image _image;

    // private int _tiltRandomizationIndex;
    // private Vector3 _movementDelta;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.color = _color;
        _image.raycastTarget = false;
        // _tiltRandomizationIndex = Random.Range(0, 7);
    }

    private void Update()
    {
        MoveToModel();
        // Tilt();
    }

    private void MoveToModel()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            _model.transform.position,
            _followSpeed * Time.deltaTime
        );
    }

    // private void FollowRotation()
    // {
    //     var movement = transform.position - _model.transform.position;
    //     _movementDelta = Vector3.Lerp(_movementDelta, movement, 25 * Time.deltaTime);
    //     Vector3 movementRotation =
    //         (parentCard.isDragging ? _movementDelta : movement) * _rotationAmount;
    //     rotationDelta = Vector3.Lerp(
    //         rotationDelta,
    //         movementRotation,
    //         rotationSpeed * Time.deltaTime
    //     );
    //     transform.eulerAngles = new Vector3(
    //         transform.eulerAngles.x,
    //         transform.eulerAngles.y,
    //         Mathf.Clamp(rotationDelta.x, -60, 60)
    //     );
    // }

    // private void Tilt()
    // {
    //     float sine = Mathf.Sin(Time.time + _tiltRandomizationIndex) * .2f;
    //     float cosine = Mathf.Cos(Time.time + _tiltRandomizationIndex) * .2f;

    //     // Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     // float tiltX = parentCard.isHovering ? ((offset.y * -1) * manualTiltAmount) : 0;
    //     // float tiltY = parentCard.isHovering ? ((offset.x) * manualTiltAmount) : 0;
    //     // float tiltZ = parentCard.isDragging ? tiltParent.eulerAngles.z : (curveRotationOffset * (curve.rotationInfluence * parentCard.SiblingAmount()));

    //     // float lerpX = Mathf.LerpAngle(tiltParent.eulerAngles.x, tiltX + (sine * autoTiltAmount), tiltSpeed * Time.deltaTime);
    //     // float lerpY = Mathf.LerpAngle(tiltParent.eulerAngles.y, tiltY + (cosine * autoTiltAmount), tiltSpeed * Time.deltaTime);
    //     // float lerpZ = Mathf.LerpAngle(tiltParent.eulerAngles.z, tiltZ, tiltSpeed / 2 * Time.deltaTime);

    //     float lerpX = Mathf.LerpAngle(
    //         transform.eulerAngles.x,
    //         sine * _tiltAmount,
    //         _tiltSpeed * Time.deltaTime
    //     );
    //     float lerpY = Mathf.LerpAngle(
    //         transform.eulerAngles.y,
    //         cosine * _tiltAmount,
    //         _tiltSpeed * Time.deltaTime
    //     );
    //     float lerpZ = Mathf.LerpAngle(
    //         transform.eulerAngles.z,
    //         0,
    //         _followSpeed / 2 * Time.deltaTime
    //     );

    //     transform.eulerAngles = new Vector3(lerpX, lerpY, lerpZ);
    // }
}
