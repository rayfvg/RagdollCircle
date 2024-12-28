using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	public float speed = 3f;

    public bool IsVertical;

    // Update is called once per frame
    void Update()
    {
        if(IsVertical) 
            transform.Rotate(0f, speed * Time.deltaTime / 0.01f, 0f, Space.Self);
        else
            transform.Rotate(0f, 0f, speed * Time.deltaTime / 0.01f, Space.Self);
    }
}
