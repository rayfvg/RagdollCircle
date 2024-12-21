using UnityEngine;
using UnityEngine.UI;

public class SwitcherScreen : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private GameObject _screenLvlMenu;

    private void OnEnable() => _startButton.onClick.AddListener(SwitchToLvlMenu);
    private void OnDisable() => _startButton.onClick.RemoveListener(SwitchToLvlMenu);
    public void SwitchToLvlMenu()
    {
        _screenLvlMenu.SetActive(true);
    }

}
