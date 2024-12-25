using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class SwitcherScreen : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private GameObject _screenLvlMenu;
    [SerializeField] private GameObject _screenLogoMenu;

    [SerializeField] private GameObject _menuInGameplay;

    [SerializeField] private GameObject _switcherCharacterMenu;
    [SerializeField] private GameObject _chanchetMenuLvls;

    private void OnEnable() => _startButton.onClick.AddListener(SwitchToLvlMenu);
    private void OnDisable() => _startButton.onClick.RemoveListener(SwitchToLvlMenu);
    public void SwitchToLvlMenu()
    {
        _screenLvlMenu.SetActive(true);
        _screenLogoMenu.SetActive(false);
    }

    public void PauseGame()
    {
        _menuInGameplay.SetActive(true);  // Показываем меню
        Time.timeScale = 0f;          // Останавливаем игровой процесс
    }

    public void ResumeGame()
    {
        _menuInGameplay.SetActive(false); // Скрываем меню
        Time.timeScale = 1f;           // Возобновляем игровой процесс
    }

    public void SwitcherSkinOpen()
    {
        _switcherCharacterMenu.SetActive(true);
        _chanchetMenuLvls.SetActive(false);
    }

    public void CloseSwitcherMenu()
    {
        _chanchetMenuLvls.SetActive(true);
        _switcherCharacterMenu.SetActive(false);
    }

}
