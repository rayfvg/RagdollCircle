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

        // Устанавливаем минимальные и максимальные значения для слайдеров
        _sliderUpDown.minValue = _hummer.transform.position.y - 1.5f; // Смещение вниз от текущей позиции
        _sliderUpDown.maxValue = _hummer.transform.position.y + 1.5f; // Смещение вверх от текущей позиции

        _sliderRightLeft.minValue = _hummer.transform.position.x - 1f; // Смещение влево от текущей позиции
        _sliderRightLeft.maxValue = _hummer.transform.position.x + 1f; // Смещение вправо от текущей позиции

        // Устанавливаем значения слайдеров равными текущей позиции молотка
        _sliderUpDown.value = _hummer.transform.position.y;
        _sliderRightLeft.value = _hummer.transform.position.x;
    }

}
