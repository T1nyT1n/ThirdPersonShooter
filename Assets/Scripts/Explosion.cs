using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage;
    [SerializeField] float maxSize;
    [SerializeField] float speed;
    void Start()
    {
        transform.localScale = Vector3.zero;
    }
    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * speed;
        if (transform.localScale.x > maxSize)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        var playerHealth = col.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.ReceiveDamage(damage);
        }
        var enemyHealth = col.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.ReceiveDamage(damage);
        }
    }
}
