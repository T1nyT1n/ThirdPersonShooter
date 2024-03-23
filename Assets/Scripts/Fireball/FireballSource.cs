using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSource : MonoBehaviour
{
    [SerializeField] Transform targetPoint;
    [SerializeField] Camera cameraLink;
    [SerializeField] float targetInSkyDistance;
    void Start()
    {
        
    }
    void Update()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.65f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            targetPoint.position = hit.point;
        } else {
            targetPoint.position = ray.GetPoint(targetInSkyDistance);
        }
        transform.LookAt(targetPoint.position);
    }
}
