using System;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HummerStrike : MonoBehaviour
{
    [SerializeField] private float _maxPower;  // Максимальная сила удара
    [SerializeField] private float _chargeSpeed = 2f; // Скорость роста/спада силы удара

    [SerializeField] private Image _powerBar;
    [SerializeField] private Button _hitButton;

    private HummerView _hummerView;

    private bool _isCharging;
    private float _currentChargeTime;
    public float CurrentPower;

    private void Awake()
    {
        _hummerView = GetComponentInParent<HummerView>(); 
    }

    private void OnEnable()
    {
        _hitButton.onClick.AddListener(OnButtonReleased);

        EventTrigger eventTrigger = _hitButton.GetComponent<EventTrigger>();
        if (eventTrigger == null)
            eventTrigger = _hitButton.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerDown
        };
        entry.callback.AddListener((eventData) => { OnButtonPressed(); });

        eventTrigger.triggers.Add(entry);
    }
    private void Update()
    {
        if (_isCharging)
        {
            ChargePower();
        }
    }

    public void OnButtonPressed()
    {
        // Начинаем заряд силы
        _isCharging = true;
        _currentChargeTime = 0f;
    }

    public void OnButtonReleased()
    {
        // Останавливаем заряд и выполняем удар
        _isCharging = false;
        PerformStrike();
    }

    private void ChargePower()
    {
        _currentChargeTime += Time.deltaTime * _chargeSpeed;

        CurrentPower = Mathf.Abs(Mathf.Sin(_currentChargeTime)) * _maxPower;

        _powerBar.fillAmount = CurrentPower / _maxPower;
    }

    private void PerformStrike()
    {
        _hummerView.StartHitView();
    }

}
