using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] Transform cameraAxis;
    [SerializeField] float rotationSpeed;
    [SerializeField] float minAngle;
    [SerializeField] float maxAngle;
    void Update()
    {
        var newAngleY = transform.localEulerAngles.y + Time.deltaTime * rotationSpeed * Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, newAngleY, 0);

        var newAngleX = cameraAxis.localEulerAngles.x - Time.deltaTime * rotationSpeed * Input.GetAxis("Mouse Y");
        if (newAngleX > 180)
        {
            newAngleX -= 360;
        }
        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);
        cameraAxis.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
