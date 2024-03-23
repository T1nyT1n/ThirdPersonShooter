using UnityEngine;

public class Throwable : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void ThrowToPoint(Vector3 throwPoint, float throwPower)
    {
        Vector3 direction = throwPoint + (Vector3.up * 2) - transform.position;
        Vector3 throwForce = direction.normalized * throwPower;
        _rigidbody.AddForce(throwForce);
    }
}
