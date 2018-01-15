using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    public bool isGrounded;
    private Rigidbody rb;
    public float jumpHeight;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
    }

	void Update () {
		if (isGrounded && Input.GetKeyDown(KeyCode.Z))
        {
            rb.velocity = new Vector3(0, 10 * jumpHeight * Time.deltaTime);
            isGrounded = false;
        }
	}
}
