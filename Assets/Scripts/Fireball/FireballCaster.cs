using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    [SerializeField] Fireball fireballPrefab;
    [SerializeField] Transform fireballSourceTransform;
    public float damage;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var fireball = Instantiate(fireballPrefab, fireballSourceTransform.transform.position, fireballSourceTransform.transform.rotation);
            fireball.damage = damage;
        }
    }
}
