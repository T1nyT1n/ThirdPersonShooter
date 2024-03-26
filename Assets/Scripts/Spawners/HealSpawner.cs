using System.Collections.Generic;
using UnityEngine;

public class HealSpawner : MonoBehaviour
{
    [SerializeField] private HealthCollectable _healPrefab;
    [SerializeField] private float timeToSpawn;
    
    private List<Transform> _spawnerPoints;
    private HealthCollectable _heal;

    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _spawnerPoints.RemoveAt(0);
    }
    private void Update()
    {
        if (_heal != null) return;
        if (IsInvoking()) return;
        Invoke("SpawnHeal", timeToSpawn);
    }

    private void SpawnHeal()
    {
        _heal = Instantiate(_healPrefab);
        _heal.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
    }
}
