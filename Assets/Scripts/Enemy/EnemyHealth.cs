using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value;
    public float physDamageMultiplier;
    
    private PlayerProgress _playerProgress;
    private EnemyAI _enemyAIScript;
    private NavMeshAgent _navMeshAgentComponent;

    private void Start()
    {
        _playerProgress = FindObjectOfType<PlayerProgress>();
        _enemyAIScript = GetComponent<EnemyAI>();
        _navMeshAgentComponent = GetComponent<NavMeshAgent>();
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.relativeVelocity.magnitude > 10)
        {
            ReceiveDamage(col.relativeVelocity.magnitude * physDamageMultiplier);
        }
    }
    public void ReceiveDamage(float damage)
    {
        value -= damage;
        _playerProgress.AddExperience(damage);
        if(value <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void StopEnemy(float time)
    {
        StartCoroutine(CoroutineStopEnemy(time));
    }
    IEnumerator CoroutineStopEnemy(float time)
    {
        if (_enemyAIScript.enabled)
        {
            _enemyAIScript.enabled = false;
            _navMeshAgentComponent.enabled = false;

            yield return new WaitForSeconds(time);
            
            _enemyAIScript.enabled = true;
            _navMeshAgentComponent.enabled = true;
        }
    }
}
