using UnityEngine;

public class LoseRules : MonoBehaviour
{
    [SerializeField] private FinishPlatform _finishPlatform;

    [SerializeField] private GameObject _loseTable;
    private Enemy _enemy;

    private Rigidbody _rigidbody;

    private bool _isMoving = false;
  

    private void OnEnable()
    {
        _isMoving = false;
        
    }

    public void InitLoseRules(Enemy enemy)
    {
        _enemy = enemy;
        CameraTarget target = _enemy.GetComponentInChildren<CameraTarget>();
        _rigidbody = target.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_rigidbody != null && _finishPlatform._isFinished == false)
        {
            if (_isMoving && _rigidbody.velocity.magnitude < 0.1f)
            {
                Debug.Log("Lose");
                _loseTable.SetActive(true);
                Destroy(_enemy.gameObject);
                _isMoving = false; // Останавливаем проверку после поражения
            }

            if (!_isMoving && _rigidbody.velocity.magnitude > 0.5f)
            {
                _isMoving = true;
            }
        }
    }
}
