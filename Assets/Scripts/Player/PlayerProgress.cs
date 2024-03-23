using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    [SerializeField] private List<PlayerProgressLevel> _levels;
    [SerializeField] private RectTransform _experienceValueRectTransform;
    [SerializeField] private TextMeshProUGUI _levelValueTMP;

    private int _levelValue = 1;
    private float _experienceCurrentValue = 0.0f;
    private float _experienceTargetValue = 100.0f;
    
    private void Start()
    {
        SetLevel(_levelValue);
        DrawUI();
    }

    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if (_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(_levelValue + 1);
            _experienceCurrentValue = 0f;
        }
        DrawUI();
    }
    private void SetLevel(int value)
    {
        var currentLevel = _levels[_levelValue - 1];
        
        _levelValue = value;
        _experienceTargetValue = currentLevel.experienceForTheNextLevel;

        GetComponent<FireballCaster>().damage = currentLevel.bubbleDamage;
    }
    private void DrawUI()
    {
        _experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1f);
        _levelValueTMP.text = _levelValue.ToString();
    }
}
