using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartLevels : MonoBehaviour
{
    [SerializeField] private GameObject _levelPrefab;
    [SerializeField] private GameObject _mainMenu;

    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private int _id;

    [SerializeField] private GameObject[] _stars;
    [SerializeField] private FinishPlatform _finishPlatform;

    private Button _buttonStartLvl;

    private int _scoreCurrentLvl;

    private void Awake()
    {
        _scoreCurrentLvl = PlayerPrefs.GetInt("_id");
        _currentScore.text = _scoreCurrentLvl.ToString();

        _buttonStartLvl = GetComponent<Button>();

        UpdateStarsForMenu();
    }

    public void StartLevel()
    {
        _levelPrefab.SetActive(true);
        _levelPrefab.GetComponent<Bootstrap>().Initialize();
        _mainMenu.gameObject.SetActive(false);
    }

    private void OnEnable() => _buttonStartLvl.onClick.AddListener(StartLevel);
    private void OnDisable() => _buttonStartLvl.onClick.RemoveListener(StartLevel);

    public void TryUpdateValueScore()
    {
        _scoreCurrentLvl = PlayerPrefs.GetInt("_id");
        _currentScore.text = _scoreCurrentLvl.ToString();
        UpdateStarsForMenu();
    }

    public void UpdateStarsForMenu()
    {
        if (_scoreCurrentLvl >= _finishPlatform.ScoreFor1Starr)
            _stars[0].SetActive(true);
        if (_scoreCurrentLvl >= _finishPlatform.ScoreFor2Starr)
            _stars[1].SetActive(true);
        if (_scoreCurrentLvl >= _finishPlatform.ScoreFor3Starr)
            _stars[2].SetActive(true);
    }
}
