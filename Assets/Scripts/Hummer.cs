using System.Collections;
using UnityEngine;

public class Hummer : MonoBehaviour
{
    [SerializeField] private HummerStrike _hummerStrike;

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if(enemy != null)
        {
            Vector3 forceDirection = transform.right;

            Vector3 contactPoint = collision.contacts[0].point;
 
            enemy.TakeDamage(forceDirection * _hummerStrike.CurrentPower, contactPoint);
            StartCoroutine(DelayForDisableCollider());
        }
    }

    private IEnumerator DelayForDisableCollider()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Collider>().enabled = false;
    }
}
