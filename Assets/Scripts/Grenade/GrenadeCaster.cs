using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    [SerializeField] Rigidbody grenadePrefab;
    [SerializeField] Transform grenadeSourceTransform;
    [SerializeField] float force;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = grenadeSourceTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(grenadeSourceTransform.forward * force);
        }
    }
}
