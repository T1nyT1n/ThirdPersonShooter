using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    [SerializeField] Fireball fireballPrefab;
    [SerializeField] Transform fireballSourceTransform;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fireballPrefab, fireballSourceTransform.transform.position, fireballSourceTransform.transform.rotation);
        }
    }
}
