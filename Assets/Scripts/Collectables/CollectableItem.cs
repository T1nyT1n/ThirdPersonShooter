using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    private ICollectableLogic _collectableLogic;

    private void Awake()
    {
        _collectableLogic = GetComponent<ICollectableLogic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            bool shouldDetele = _collectableLogic.OnCollected(playerController);
            if (shouldDetele)
            {
                Destroy(gameObject);
            }
        }
    }
}