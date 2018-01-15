using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 5;
    private  Rigidbody2D theRigidbody;

	// Use this for initialization
	void Start () {
        theRigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("right"))
        {
            transform.Translate(new Vector2(1, 0) * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey("left"))
        {
            transform.Translate(new Vector2(-1, 0) * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            moveSpeed = 0;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            moveSpeed = 5;
        }
    }

    public void Jump()
    {

    }
}
