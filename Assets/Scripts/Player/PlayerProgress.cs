using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    [SerializeField] private List<PlayerProgressLevel> _levels;
    [SerializeField] private RectTransform _experienceValueRectTransform;
    [SerializeField] private TextMeshProUGUI _levelValueTMP;
    [SerializeField] private GameObject newEnemys;

    private int _levelValue = 1;
    private float _experienceCurrentValue = 0.0f;
    private float _experienceTargetValue = 100.0f;
    
    private void Start()
    {
        GetComponent<AbilityController>().enabled = false;
        SetLevel(_levelValue);
        DrawUI();
    }

    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if (_experienceCurrentValue >= _experienceTargetValue)
        {
            _levelValue += 1;
            SetLevel(_levelValue);
            _experienceCurrentValue = 0f;
        }
        DrawUI();
    }
    private void SetLevel(int value)
    {
        var currentLevel = _levels[_levelValue - 1];
        
        _levelValue = value;
        _experienceTargetValue = currentLevel.experienceForTheNextLevel;

        GetComponent<FireballCaster>().freezeTime = currentLevel.bubbleFreezeTime;
        if (currentLevel.abilityAvailable) 
        {
            var abilityScript = GetComponent<AbilityController>();
            abilityScript.enabled = true;
            abilityScript.ActivateAbilityTimer();
        }
        if (_levelValue >= 4)
        {
            newEnemys.SetActive(true);
        }
    }
    private void DrawUI()
    {
        _experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1f);
        _levelValueTMP.text = _levelValue.ToString();
    }
}
