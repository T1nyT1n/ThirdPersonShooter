using UnityEngine;

public class AbilityController : MonoBehaviour
{
    [SerializeField] private float _abilityRestoreDuration = 1.0f;
    [SerializeField] private float _boxCastRadius = 10.0f;
    [SerializeField] private float _throwPower = 30.0f;
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private Camera _camera;

    private float _timer;

    private void Update()
    {
        UpdateTimer();
        if (Input.GetKeyDown(KeyCode.Q) && CanApplyAbility() && TryApplyAbility())
        {
            RestoreTimer();
        }
    }

    private bool CanApplyAbility()
    {
        return _timer >= _abilityRestoreDuration;
    }

    private void UpdateTimer()
    {
        _timer += Time.deltaTime;
    }

    private void RestoreTimer()
    {
        _timer = 0.0f;
    }

    private bool TryApplyAbility()
    {
        if (!TryGetThrowPoint(out Vector3 throwPoint))
        {
            return false;
        }
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, _boxCastRadius, transform.forward);
        bool result = false;
        foreach (RaycastHit hit in hits)
        {
            if (IsThrowable(hit, out Throwable throwable))
            {
                throwable.ThrowToPoint(throwPoint, _throwPower);
                result = true;
            }
        }
        return result;
    }

    private bool TryGetThrowPoint(out Vector3 throwPoint)
    {
        if (Physics.Raycast(_raycastPoint.position, _camera.transform.forward, out RaycastHit hit))
        {
            throwPoint = hit.point;
            return true;
        }
        throwPoint = Vector3.negativeInfinity;
        return false;
    }

    private bool IsThrowable(RaycastHit hit, out Throwable throwable)
    {
        if (hit.rigidbody == null)
        {
            throwable = null;
            return false;
        }
        return hit.rigidbody.TryGetComponent(out throwable);
    }
}
