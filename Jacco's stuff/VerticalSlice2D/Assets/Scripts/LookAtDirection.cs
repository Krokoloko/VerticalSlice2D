using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtDirection : MonoBehaviour {


    public Transform topTarget;
    public Transform leftTarget;
    public Transform rightTarget;
    public Transform topRightTarget;
    public Transform topLeftTarget;
    public Transform downTarget;
    public Transform downLeftTarget;
    public Transform downRightTarget;
    public bool ShootDirection;
    [SerializeField]
    private PlayerShoot _playershoot;
    
    // Use this for initialization
    void Awake () {
        _playershoot = GetComponent<PlayerShoot>();
        ShootDirection = true;
	}

    // Update is called once per frame
    void Update() {

              

       

        if (Input.GetKey("up") && (Input.GetKey("right")))
        {
            transform.right = topRightTarget.position - transform.position;
        }
        else if (Input.GetKey("right"))
        {
            transform.right = rightTarget.position - transform.position;         
        }

        else if (Input.GetKey("up") && ShootDirection == true)
        {
            transform.right = topTarget.position - transform.position;         
            ShootDirection = true;
        }

        if (Input.GetKey("left") && (Input.GetKey("up")))
        {
            ShootDirection = false;
            transform.right = topLeftTarget.position - transform.position;
        }

        else if (Input.GetKey("left"))
        {
            transform.right = leftTarget.position - transform.position;
        }

        else if (Input.GetKey("down") && ShootDirection == true)
        {
            transform.right = downTarget.position - transform.position;
            ShootDirection = true;
        }

        if (Input.GetKey("down") && (Input.GetKey("left")))
        {
            ShootDirection = false;
            transform.right = downLeftTarget.position - transform.position;
        }
        
        else if (Input.GetKey("down") && (Input.GetKey("right")))
        {
            transform.right = downRightTarget.position - transform.position;
        }

        if (Input.GetKey(KeyCode.X))
        {
            _playershoot.Shoot();
        }


        if (Input.GetKeyUp("left"))
        {
            ShootDirection = true;
        }
    }
}
