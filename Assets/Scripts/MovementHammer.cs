using UnityEngine;
using UnityEngine.UI;

public class MovementHammer : MonoBehaviour
{
    [SerializeField] private HummerView _hummer;

    [SerializeField] private Slider _sliderUpDown;
    [SerializeField] private Slider _sliderRightLeft;

    private void Start()
    {
        InitializeSlider();
    }

    private void Update()
    {
        _hummer.transform.position = new Vector3(_sliderRightLeft.value, _sliderUpDown.value, 0);
    }

    private void InitializeSlider()
    {
        _sliderUpDown.minValue = _hummer.transform.position.y;
        _sliderUpDown.maxValue = _hummer.transform.position.y + 3;

        _sliderRightLeft.minValue = _hummer.transform.position.x;
        _sliderRightLeft.maxValue = _hummer.transform.position.x + 2;

        _sliderUpDown.value = (_hummer.transform.position.y + 3 + _hummer.transform.position.y) / 2;
        _sliderRightLeft.value = (_hummer.transform.position.x + 2 + _hummer.transform.position.x) / 2;
    }
}
