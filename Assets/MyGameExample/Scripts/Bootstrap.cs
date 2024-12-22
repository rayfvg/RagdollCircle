using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private GameObject _gameplayUI;
    [SerializeField] private GameObject _loseTableUi;
    [SerializeField] private GameObject _finishTable;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _locker;

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


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    private void OnEnable() => _restartButton.onClick.AddListener(Restart);
    private void OnDisable() => _restartButton.onClick.RemoveListener(Restart);

    public void Restart()
    {
        if (_enemy != null)
            Destroy(_enemy.gameObject);
        Initialize();
    }

    public void Initialize()
    {
        _enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity, transform);
        _enemyTarget = _enemy.GetComponentInChildren<CameraTarget>();
        _cameraFindPlayer.Initialize(_enemyTarget);
        _losRules.InitLoseRules(_enemy);
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
    }
}
