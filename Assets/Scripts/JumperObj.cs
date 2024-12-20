using UnityEngine;

public class JumperObj : MonoBehaviour
{
    [SerializeField] private float _forse;

    [SerializeField] private WalletScore _wallet;


    private Coroutine _currentCoroutine;
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * _forse, ForceMode.Impulse);
        int newScoreY = Mathf.Abs((int)collision.relativeVelocity.y * 10);
        int newScoreX = Mathf.Abs((int) collision.relativeVelocity.x * 10);
        _wallet.AddScoreGradually(newScoreY + newScoreX);
    }
}
