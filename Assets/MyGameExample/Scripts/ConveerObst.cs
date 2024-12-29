using UnityEngine;

public class ConveerObst : MonoBehaviour
{
    public AudioSource _conveerSound;

    [SerializeField] private float _forse;
    [SerializeField] private Vector3 _direction;

    [SerializeField] private Material _material;
    [SerializeField] private WalletScore _wallet;
    [SerializeField] private float _speed;


    private float value = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(_direction * _forse, ForceMode.Impulse);

            int newScoreY = Mathf.Abs((int)collision.relativeVelocity.y * 10);
            int newScoreX = Mathf.Abs((int)collision.relativeVelocity.x * 10);
            _wallet.AddScoreGradually(newScoreY + newScoreX);

            if (_conveerSound.isPlaying == false)
                _conveerSound.Play();
        }
    }

    private void Update()
    {
        ConveerAnimation();
    }

    private void ConveerAnimation()
    {
        value += Time.deltaTime * _speed;
        _material.mainTextureOffset = new Vector2(0, value);
    }
}