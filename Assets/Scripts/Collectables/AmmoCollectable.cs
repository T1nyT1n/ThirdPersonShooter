using UnityEngine;

public class AmmoCollectable : MonoBehaviour, ICollectableLogic
{
    private int _count = 2;

    public bool OnCollected(PlayerController playerController)
    {
        _count -= 1;
        Debug.Log("Ammo collected.");
        return _count <= 0;
    }
}