using System.Collections;
using UnityEngine;

public class ActivadeTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] _onDisableObj;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CameraTarget>() != null)
        {
            foreach (var item in _onDisableObj)
            {
                item.GetComponent<Collider>().enabled = false;
            }
            
            StartCoroutine(WainEnable());

        }
    }

    private IEnumerator WainEnable()
    {
        yield return new WaitForSeconds(2f);
        foreach (var item in _onDisableObj)
        {
            item.GetComponent<Collider>().enabled = true;
        }
        Debug.Log("tach");
    }
}