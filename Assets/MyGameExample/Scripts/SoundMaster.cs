using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void OnCollisionEnter(Collision collision)
    {
      
            Debug.Log("”пал");
            if (collision.relativeVelocity.normalized.y > 0.7 ||
                collision.relativeVelocity.normalized.x > 0.7)
            {
                _enemy.PLayHitSound();
                Debug.Log("—ильно упал");
            }
       
    }
}
