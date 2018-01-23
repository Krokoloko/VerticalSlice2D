using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour {

    public GameObject firstEnd;
    public GameObject secondEnd;

    private float firstX;
    private float secondX;


	void Start () {
        firstX = firstEnd.transform.position.x;
        secondX = secondEnd.transform.position.x;
	}

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, firstX, secondX),transform.position.y,transform.position.z);    
    }

    void LateUpdate () {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left/5);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right/5);
        }
	}
}
