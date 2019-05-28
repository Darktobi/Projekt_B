using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float cameraspeed = 0.1f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {

        if (target)
        {
            // lerp (from, To, how fast)
            transform.position = Vector3.Lerp(transform.position, target.position, cameraspeed) + new Vector3(0, 0, -10);

        }
    }
}
