using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartLevels : MonoBehaviour
{
    [SerializeField] private GameObject _levelPrefab;
    [SerializeField] private GameObject _mainMenu;

    private Button _buttonStartLvl;

    private void Awake()
    {
        _buttonStartLvl = GetComponent<Button>();
        _buttonStartLvl.onClick.AddListener(StartLevel);
    }

    public void StartLevel()
    {
        _levelPrefab.SetActive(true);

        _mainMenu.gameObject.SetActive(false);
    }

    private void OnDisable() => _buttonStartLvl.onClick.RemoveListener(StartLevel);
}
