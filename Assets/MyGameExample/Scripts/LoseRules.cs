using UnityEngine;

public class LoseRules : MonoBehaviour
{
    public AudioSource FailSound;

    [SerializeField] private FinishPlatform _finishPlatform;

    [SerializeField] private GameObject _loseTable;
    private Enemy _enemy;

    private Rigidbody _rigidbody;

    private bool _isMoving = false;
    private bool _isChecking = false;

    private void OnEnable()
    {
        _isMoving = false;
        _isChecking = false;
    }

    public void InitLoseRules(Enemy enemy)
    {
        _enemy = enemy;
        CameraTarget target = _enemy.GetComponentInChildren<CameraTarget>();
        _rigidbody = target.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_rigidbody != null && !_finishPlatform._isFinished)
        {
            if (!_isChecking && _isMoving && _rigidbody.velocity.magnitude < 0.1f)
            {
                StartCoroutine(CheckLoseCondition());
            }

            if (!_isMoving && _rigidbody.velocity.magnitude > 0.5f)
            {
                _isMoving = true;
            }
        }
    }

    private System.Collections.IEnumerator CheckLoseCondition()
    {
        _isChecking = true;

        // Ждём 1 секунду перед проверкой
        yield return new WaitForSeconds(1f);

        // Проверяем, остановился ли объект
        if (_rigidbody.velocity.magnitude < 0.1f && _isMoving)
        {
            FailSound.Play();
            Debug.Log("Lose");
            _loseTable.SetActive(true);
            Destroy(_enemy.gameObject);
            _isMoving = false;
        }

        _isChecking = false;
    }

    public void RulesUpdate()
    {
        _isMoving = false;
        _isChecking = false;
    }
}
