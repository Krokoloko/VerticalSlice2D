using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour {

    public Transform Target;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public bool debug;


    void LateUpdate()
    {
        if (!debug)
        {
            transform.position = new Vector3(Mathf.Clamp(Target.position.x, minX, maxX), Mathf.Clamp(Target.position.y, minY, maxY), transform.position.z);
        }

        if (debug)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left / 5);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right / 5);
            }
        }
        

    }
}
