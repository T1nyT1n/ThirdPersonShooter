using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] float speed;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void FixedUpdate() 
    {
        transform.position += transform.forward * Time.fixedDeltaTime * speed;
    }
}
