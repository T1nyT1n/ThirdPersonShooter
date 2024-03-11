using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float delay;
    void Explosion()
    {
        Destroy(gameObject);
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", delay);
    }
}
