using System.Collections;
using UnityEngine;

public class Hummer : MonoBehaviour
{
    [SerializeField] private HummerStrike _hummerStrike;
    [SerializeField] private GameObject _locker;

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if(enemy != null)
        {
            Vector3 forceDirection = transform.right;

            Vector3 contactPoint = collision.contacts[0].point;
 
            enemy.TakeDamage(forceDirection * _hummerStrike.CurrentPower, contactPoint);

            _locker.SetActive(true);
            StartCoroutine(DelayForDisableCollider());
        }
    }

    private IEnumerator DelayForDisableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Collider>().enabled = false;
    }
}
