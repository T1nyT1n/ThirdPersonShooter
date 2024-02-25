using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] Transform _cameraAxis;
    [SerializeField] float _rotationSpeed;
    [SerializeField] float _minAngle;
    [SerializeField] float _maxAngle;
    void Update()
    {
        var newAngleY = transform.localEulerAngles.y + Time.deltaTime * _rotationSpeed * Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, newAngleY, 0);

        var newAngleX = _cameraAxis.localEulerAngles.x - Time.deltaTime * _rotationSpeed * Input.GetAxis("Mouse Y");
        if (newAngleX > 180)
        {
            newAngleX -= 360;
        }
        newAngleX = Mathf.Clamp(newAngleX, _minAngle, _maxAngle);
        _cameraAxis.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
