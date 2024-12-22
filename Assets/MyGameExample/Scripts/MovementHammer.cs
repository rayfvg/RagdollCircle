using UnityEngine;
using UnityEngine.UI;

public class MovementHammer : MonoBehaviour
{
    [SerializeField] private HummerView _hummer;

    [SerializeField] private Slider _sliderUpDown;
    [SerializeField] private Slider _sliderRightLeft;

    private void Update()
    {
        _hummer.transform.position = new Vector3(_sliderRightLeft.value, _sliderUpDown.value, 0);
    }

    public void InitializeSlider()
    {
        _hummer.transform.position = new Vector3(0, 0, 0);

        // ������������� ����������� � ������������ �������� ��� ���������
        _sliderUpDown.minValue = _hummer.transform.position.y - 1.5f; // �������� ���� �� ������� �������
        _sliderUpDown.maxValue = _hummer.transform.position.y + 1.5f; // �������� ����� �� ������� �������

        _sliderRightLeft.minValue = _hummer.transform.position.x - 1f; // �������� ����� �� ������� �������
        _sliderRightLeft.maxValue = _hummer.transform.position.x + 1f; // �������� ������ �� ������� �������

        // ������������� �������� ��������� ������� ������� ������� �������
        _sliderUpDown.value = _hummer.transform.position.y;
        _sliderRightLeft.value = _hummer.transform.position.x;
    }

}
