using UnityEngine;

public class BounserUp : MonoBehaviour
{

    [SerializeField] private float _forse;
    [SerializeField] private Vector3 _direction;

    public bool IsEnable = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
            if (IsEnable == true)
                other.gameObject.GetComponent<Rigidbody>().AddForce(_direction * _forse, ForceMode.VelocityChange);
    }
}
