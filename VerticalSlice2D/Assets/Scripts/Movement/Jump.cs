using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
    
    public float jumpForce = 12f;
    public float jumpMultiplier = 3f;
    public float lowJumpMultiplier = 5f;

    public bool _grounded = false;
    public bool _isDucking = false;

    Rigidbody2D rigidB;
    BoxCollider2D boxC;

    void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>();
        boxC = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Duck();
        if(Input.GetButtonDown("Jump")&& _grounded == true && _isDucking == false)
        {
            rigidB.velocity += Vector2.up * jumpForce;
            _grounded = false;
        }

        if(rigidB.velocity.y < 0)
        {
            rigidB.velocity += Vector2.up * Physics2D.gravity.y * (jumpMultiplier - 1) * Time.deltaTime;
        }
        else if(rigidB.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigidB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) && _grounded == true)
        {
            _isDucking = true;
        }
        else
        {
            _isDucking = false;
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            _grounded = true;
        }
        else
        {
            return;
        }
            
    }

    void Duck()
    {
        if(_isDucking == true)
        {
            boxC.enabled = false;
        }
        else
        {
            boxC.enabled = true;
        }
    }
    
    

}
