using UnityEngine;

public class HealthCollectable : MonoBehaviour, ICollectableLogic
{
    [SerializeField] float healAmount;
    public bool OnCollected(PlayerController playerController)
    {
        playerController.GetComponent<PlayerHealth>().AddHealth(healAmount);
        return true;
    }
}