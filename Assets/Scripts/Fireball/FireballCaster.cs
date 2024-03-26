using TMPro;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    [SerializeField] Fireball fireballPrefab;
    [SerializeField] Transform fireballSourceTransform;
    [SerializeField] private Transform uiInactiveBackground;
    [SerializeField] private TextMeshProUGUI uiCooldownTimerText;
    public float freezeTime;
    public float cooldown;

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(1) && _timer >= cooldown)
        {
            var fireball = Instantiate(fireballPrefab, fireballSourceTransform.transform.position, fireballSourceTransform.transform.rotation);
            fireball.timeForStopping = freezeTime;
            _timer = 0f;
        }
        DrawUI(_timer >= cooldown);
    }
    void DrawUI(bool canShoot)
    {
        if (!canShoot)
        {
            uiInactiveBackground.gameObject.SetActive(true);
            var textNumber = cooldown - _timer;
            textNumber = Mathf.Round(textNumber * 10.0f) * 0.1f;
            uiCooldownTimerText.text = textNumber.ToString();
        } else {
            uiInactiveBackground.gameObject.SetActive(false);
        }
    }
}
