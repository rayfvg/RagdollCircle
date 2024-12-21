using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;


    [SerializeField] private CameraFindPLayer _cameraFindPlayer;
    [SerializeField] private WalletScore _wallet;

    [SerializeField] public Hummer _hummer;

    private Enemy _enemy;
    private CameraTarget _enemyTarget;

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
    
    public void Initialize()
    {
        _enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity, transform);
        _enemyTarget = _enemy.GetComponentInChildren<CameraTarget>();
        _cameraFindPlayer.Initialize(_enemyTarget);
    }
}
