using UnityEngine;

public class PressUp : MonoBehaviour
{
    [SerializeField] private float _forse;
    [SerializeField] private Vector3 _direction;

    [SerializeField] private WalletScore _wallet;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _animationCooldown = 1f; // Задержка между вызовами анимации
    private bool _canAnimate = true;




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(_direction * _forse, ForceMode.Impulse);
            if (_canAnimate)
                StartAnimation();

            int newScoreY = Mathf.Abs((int)collision.relativeVelocity.y * 10);
            int newScoreX = Mathf.Abs((int)collision.relativeVelocity.x * 10);
            _wallet.AddScoreGradually(newScoreY + newScoreX);
        }
    }

    private void StartAnimation()
    {
        if (_animator != null)
            _animator.SetTrigger("jump");
        _canAnimate = false;
        Invoke(nameof(ResetAnimationCooldown), _animationCooldown);
    }

    private void ResetAnimationCooldown()
    {
        _canAnimate = true;
    }

}