using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifetime;
    public float damage;
    public float timeForStopping;

    private EnemyHealth _enemyHealthComponent;
    private SphereCollider _bubbleCollider;
    private bool _fireballStopped = false;
    
    void Start()
    {
        _bubbleCollider = GetComponent<SphereCollider>();   
        Invoke("DestroyFireball", _lifetime);
    }
    void OnCollisionEnter(Collision other)
    {
        GetEnemyComponent(other);
        if (_enemyHealthComponent != null)
        {
            EnemyStopBubble(other);
        }
    }
    void FixedUpdate() 
    {
        MoveFixedUpdate();
    }

    void MoveFixedUpdate()
    {
        if(!_fireballStopped)
        {
            transform.position += transform.forward * Time.fixedDeltaTime * _speed;
        }
    }
    void GetEnemyComponent(Collision col)
    {
        _enemyHealthComponent = col.gameObject.GetComponent<EnemyHealth>();
    }
    void DealDamage()
    {
        _enemyHealthComponent.ReceiveDamage(damage);
    }
    void EnemyStopBubble(Collision col)
    {
        _enemyHealthComponent.StopEnemy(timeForStopping);
        
        CancelInvoke();
        _fireballStopped = true;
        Invoke("DestroyFireball", timeForStopping);

        _bubbleCollider.enabled = false;
        
        transform.SetParent(_enemyHealthComponent.transform);
        transform.localPosition = Vector3.up;
        transform.localScale = new Vector3(1f, 2f, 1f);
    }
    void DestroyFireball()
    {
        Destroy(gameObject);
    }
}
