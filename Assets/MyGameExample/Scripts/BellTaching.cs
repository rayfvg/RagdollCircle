using UnityEngine;

public class BellTaching : MonoBehaviour
{
    [SerializeField] private float _forse;

    [SerializeField] private WalletScore _wallet;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _animationCooldown = 1f; // Задержка между вызовами анимации
    private bool _canAnimate = true;

    private Coroutine _currentCoroutine;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * _forse, ForceMode.Impulse);
            if (_canAnimate)
                StartAnimation();

            int newScoreY = Mathf.Abs((int)collision.relativeVelocity.y + 3 * 10);
            int newScoreX = Mathf.Abs((int)collision.relativeVelocity.x + 3 * 10);
            _wallet.AddScoreGradually(newScoreY + newScoreX);
        }
    }

    private void StartAnimation()
    {
        _animator.SetTrigger("bell");
        _canAnimate = false;
        Invoke(nameof(ResetAnimationCooldown), _animationCooldown);
    }

    private void ResetAnimationCooldown()
    {
        _canAnimate = true;
    }
}
