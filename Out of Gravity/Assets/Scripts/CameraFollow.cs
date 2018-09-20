using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public float cameraspeed = 0.1f;
    public Transform target;

    private static bool cameraExists;

    Camera myCam;
    // Use this for initialization
    void Start()
    {
        myCam = GetComponent<Camera>();

        DontDestroyOnLoad(transform.gameObject);

        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }



    // Update is called once per frame
    void Update()
    {

        // myCam.orthographicSize = (Screen.height / 100f) / 2f;

        if (target)
        {
            // lerp (from, To, how fast)
            transform.position = Vector3.Lerp(transform.position, target.position, cameraspeed) + new Vector3(0, 0, -10);

        }
    }
}
