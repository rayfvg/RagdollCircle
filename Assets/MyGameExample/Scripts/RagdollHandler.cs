using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RagdollHandler : MonoBehaviour
{
    private List<Rigidbody> _rigitbodyes;
    public void Initialize()
    {
        _rigitbodyes = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
        Disable();
    }

    public void Hit(Vector3 force, Vector3 hitPosition)
    {
        Rigidbody injuredRigidbody = _rigitbodyes.OrderBy(rigitbody => Vector3.Distance(rigitbody.position, hitPosition)).First();

        injuredRigidbody.AddForceAtPosition(force, hitPosition, ForceMode.Impulse);
    }

    public void Enable()
    {
        foreach (Rigidbody rigitbody in _rigitbodyes)
            rigitbody.isKinematic = false;
    }

    public void Disable()
    {
        foreach (Rigidbody rigitbody in _rigitbodyes)
            rigitbody.isKinematic = true;
    }
}
