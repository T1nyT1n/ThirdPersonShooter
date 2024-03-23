using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value;
    private PlayerProgress playerProgress;
    private void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }
    public void ReceiveDamage(float damage)
    {
        value -= damage;
        playerProgress.AddExperience(damage);
        if(value <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
