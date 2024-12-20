using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class HummerStrike : MonoBehaviour
{
    [SerializeField] private Button _strikeButton;
    [SerializeField] private float _maxPower;  // ������������ ���� �����
    [SerializeField] private float _chargeSpeed = 2f; // �������� �����/����� ���� �����

    [SerializeField] private Hummer _hummer;
    [SerializeField] private HummerView _hummerView;
    [SerializeField] private Image _powerBar;

    private bool _isCharging;
    private float _currentChargeTime;
    public float CurrentPower;

    private void Update()
    {
        if (_isCharging)
        {
            ChargePower();
        }
    }

    public void OnButtonPressed()
    {
        // �������� ����� ����
        _isCharging = true;
        _currentChargeTime = 0f;
    }

    public void OnButtonReleased()
    {
        // ������������� ����� � ��������� ����
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
