using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherUpper : MonoBehaviour
{
    [SerializeField] private BounserUp _bounserUp;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider != null)
            _bounserUp.IsEnable = true;
    }
}
