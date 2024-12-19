using UnityEngine;
using UnityEngine.UI;

public class GameplayTest : MonoBehaviour
{
    private Enemy _enemy;
    private CameraTarget _enemyTarget;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] public Hummer _hummer;
    [SerializeField] private HummerView _view;

    [SerializeField] private CameraFindPLayer _cameraFindPlayer;

    [SerializeField] private Button _hitButton;

    private void Awake()
    {
        Initialize();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _view.StartHitView();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
            _view.SwitchIdleView();
        }
    }

    private void OnEnable()
    {
        _hitButton.onClick.AddListener(AttackHummer);
    }
    private void OnDisable()
    {
        _hitButton.onClick.RemoveListener(AttackHummer);
    }

    public void Restart()
    {
        Destroy(_enemy.gameObject);
        Initialize();
    }
    
    private void Initialize()
    {
        _enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
        _enemyTarget = _enemy.GetComponentInChildren<CameraTarget>();
        _cameraFindPlayer.Initialize(_enemyTarget);
    }

    private void AttackHummer() => _view.StartHitView();
}
