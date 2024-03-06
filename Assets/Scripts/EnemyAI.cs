using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    PlayerHealth _playerHealth;
    [SerializeField] List<Transform> _patrolPoints;
    [SerializeField] PlayerController player;
    [SerializeField] float viewAngle;
    [SerializeField] float damage;
    bool isPlayerNoticed;
    
    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }
    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        AttackUpdate();
        PatrolUpdate();
    }
    
    void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }
    void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = _patrolPoints[Random.Range(0, _patrolPoints.Count)].position;
    }
    void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        isPlayerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {    
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    isPlayerNoticed = true;
                }
            }
        }
    }
    void ChaseUpdate()
    {
        if (isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
    void PatrolUpdate()
    {
        if(!isPlayerNoticed && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance) 
        {
            PickNewPatrolPoint();
        }
    }
    void AttackUpdate()
    {
        if (isPlayerNoticed && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _playerHealth.ReceiveDamage(damage * Time.deltaTime);
        }
    }
}
