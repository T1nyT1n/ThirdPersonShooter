using UnityEngine;

public class Health : MonoBehaviour
{
    public float value;
    void Start()
    {
        
    }
    void Update()
    {
        if(value <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void ReceiveDamage(float damage)
    {
        value -= damage;
    }
}
