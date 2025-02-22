using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource[] _sounds;

    [SerializeField] private Enemy[] _enemyPrefabs;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private GameObject _gameplayUI;
    [SerializeField] private GameObject _loseTableUi;
    [SerializeField] private GameObject _finishTable;
    [SerializeField] private GameObject _menuIngameplayUI;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _resetInMenuButton;
    [SerializeField] private GameObject _locker;
    [SerializeField] private GameObject _buttonsUI;
    [SerializeField] private Image _hitButton;

    [SerializeField] private FinishPlatform _finishPlatform;

    [SerializeField] private CameraFindPLayer _cameraFindPlayer;
    [SerializeField] private WalletScore _wallet;

    [SerializeField] public Hummer _hummer;
    [SerializeField] public MovementHammer _movementHammer;

    [SerializeField] public LoseRules _losRules;

    private Enemy _enemy;
    private CameraTarget _enemyTarget;


    //private void Awake()
    //{
    //    Initialize();
    //}




    private void OnEnable()
    {
        _restartButton.onClick.AddListener(Restart);
        _resetInMenuButton.onClick.AddListener(Restart);

        AudioListener.pause = false;
        _music.Play();
    }
    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(Restart);
        _resetInMenuButton.onClick.RemoveListener(Restart);

        _music.Stop();
        foreach (var item in _sounds)
        {
            item.Stop();
        }
    }

    public void Restart()
    {
        if (_enemy != null)
            Destroy(_enemy.gameObject);

        _finishPlatform.ResetInFinishPlase();
        AudioListener.pause = false;
        Initialize();
    }

    public void Initialize()
    {
        Time.timeScale = 1;
        _enemy = Instantiate(SelectedEnemy(), _spawnPoint.position, Quaternion.identity, transform);
        _enemyTarget = _enemy.GetComponentInChildren<CameraTarget>();
        _cameraFindPlayer.Initialize(_enemyTarget);
        _losRules.InitLoseRules(_enemy);
        _losRules.RulesUpdate();
        _movementHammer.InitializeSlider();
        _wallet.ResetScore();
        _hummer.GetComponent<Collider>().enabled = true;
        StartLvlInit();
    }

    public void StartLvlInit()
    {
        _loseTableUi.SetActive(false);
        _gameplayUI.SetActive(true);
        _finishTable.SetActive(false);
        _locker.SetActive(false);
        _buttonsUI.SetActive(true);
        _menuIngameplayUI.SetActive(false);
        _hitButton.fillAmount = 1;
    }

    private Enemy SelectedEnemy()
    {
        if (PlayerPrefs.GetInt("Bloomselect") == 1)
            return _enemyPrefabs[0];

        if (PlayerPrefs.GetInt("Thavelselect") == 1)
            return _enemyPrefabs[1];

        if (PlayerPrefs.GetInt("Circleselect") == 1)
            return _enemyPrefabs[2];

        return _enemyPrefabs[0];
    }
}
