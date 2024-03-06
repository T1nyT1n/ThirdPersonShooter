using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value;
    [SerializeField] RectTransform valueRectTransform;
    [SerializeField] GameObject gameplayUI;
    [SerializeField] GameObject gameOverScreenUI;
    float _maxValue;
    
    
    void Start()
    {
        _maxValue = value;

        DrawHealthBar();
    }


    void DrawHealthBar() 
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }
    void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreenUI.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }
    public void ReceiveDamage(float damage)
    {
        value -= damage;
        if(value <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();
    }
}
