using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifetime;
    [SerializeField] float damage;
    
    void Start()
    {
        Invoke("DestroyFireball", lifetime);
    }
    void OnCollisionEnter(Collision other)
    {
        DealDamage(other);
        DestroyFireball();
    }
    void FixedUpdate() 
    {
        MoveFixedUpdate();
    }
    void MoveFixedUpdate()
    {
        transform.position += transform.forward * Time.fixedDeltaTime * speed;
    }
    void DealDamage(Collision col)
    {
        var component = col.gameObject.GetComponent<EnemyHealth>();
        if (component != null)
        {
            component.ReceiveDamage(damage);
        }
    }
    void DestroyFireball()
    {
        Destroy(gameObject);
    }
}
