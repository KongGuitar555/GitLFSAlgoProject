using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
   
    public Transform target;
    public float lerpSpeed;

    private void Update()
    {
        transform.LookAt(target);
    }

}
