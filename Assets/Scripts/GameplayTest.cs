using UnityEngine;
using UnityEngine.UI;

public class GameplayTest : MonoBehaviour
{
    private Enemy _enemy;
    private CameraTarget _enemyTarget;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] public Hummer _hummer;

    [SerializeField] private CameraFindPLayer _cameraFindPlayer;
    [SerializeField] private WalletScore _wallet;

    private void Awake()
    {
        Initialize();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void Restart()
    {
        Destroy(_enemy.gameObject);
        Initialize();
        _hummer.GetComponent<Collider>().enabled = true;
        _wallet.ResetScore();
    }
    
    private void Initialize()
    {
        _enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
        _enemyTarget = _enemy.GetComponentInChildren<CameraTarget>();
        _cameraFindPlayer.Initialize(_enemyTarget);
    }
}
