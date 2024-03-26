using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private Transform aimTargetPoint;
    [SerializeField] private Vector3 aimPointOnScreen; // точка для ViewportPointToRay
    private Camera cameraLink;

    private void Start()
    {
        cameraLink = Camera.main;
    }

    public Ray GetCameraRay()
    {
        return cameraLink.ViewportPointToRay(aimPointOnScreen);
    }

    public Transform GetTargetPoint()
    {
        return aimTargetPoint;
    }

    public Vector3 GetDirectionToTargetPoint(Transform objectTransform)
    {
        return aimTargetPoint.position - objectTransform.position;
    }

    public void AimToPlayersTargetPoint(Transform objectTransform, float maxRayDistance)
    {
        var target = GetTargetPoint();
        var ray = GetCameraRay();
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            target.position = hit.point;
        } else {
            target.position = ray.GetPoint(maxRayDistance);
        }
        objectTransform.LookAt(target.position);
    }
}
