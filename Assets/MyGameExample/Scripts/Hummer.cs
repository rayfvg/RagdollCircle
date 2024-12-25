using System.Collections;
using UnityEngine;

public class Hummer : MonoBehaviour
{
    [SerializeField] private HummerStrike _hummerStrike;
    [SerializeField] private GameObject _locker;
    [SerializeField] private GameObject _buttonsUi;

    [SerializeField] private WalletScore _wallet;

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if(enemy != null)
        {
            Vector3 forceDirection = transform.right;

            Vector3 contactPoint = collision.contacts[0].point;
 
            enemy.TakeDamage(forceDirection * _hummerStrike.CurrentPower, contactPoint);

            int newScoreY = Mathf.Abs((int)collision.relativeVelocity.y + 5 * 10);
            int newScoreX = Mathf.Abs((int)collision.relativeVelocity.x + 5 * 10);
            _wallet.AddScoreGradually(newScoreY + newScoreX);


            _locker.SetActive(true);
            _buttonsUi.SetActive(false);
            StartCoroutine(DelayForDisableCollider());
        }
    }

    private IEnumerator DelayForDisableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Collider>().enabled = false;
    }
}
