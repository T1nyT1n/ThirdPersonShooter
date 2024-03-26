using UnityEngine;

public class FireballSource : MonoBehaviour
{
    [SerializeField] float targetInSkyDistance;
    private PlayerAim _playerAimComponent;
    private Transform _targetPoint;
    void Start()
    {
        _playerAimComponent = GetComponentInParent<PlayerAim>();
        _targetPoint = _playerAimComponent.GetTargetPoint();
    }
    void Update()
    {   
        /*
        var ray = _playerAimComponent.GetCameraRay();
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            _targetPoint.position = hit.point;
        } else {
            _targetPoint.position = ray.GetPoint(targetInSkyDistance);
        }
        transform.LookAt(_targetPoint.position);
        */
        _playerAimComponent.AimToPlayersTargetPoint(transform, targetInSkyDistance);
    }
}
