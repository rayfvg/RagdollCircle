using UnityEngine;

public class Hummer : MonoBehaviour
{
    [SerializeField] private float _forse;
    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if(enemy != null)
        {
            Vector3 forceDirection = transform.right;

            Vector3 contactPoint = collision.contacts[0].point;
 

            enemy.TakeDamage(forceDirection * _forse, contactPoint);
        }
    }
}
