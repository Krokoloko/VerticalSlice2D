using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningEnemy : Enemy {

    private Ray ray;
    private string platform;
    public bool leftSide;

    private void CheckSide()
    {
        if (transform.position.x < transform.position.x)
        {
            leftSide = false;
            base.spriteRend.flipY = true;
        }
        else
        {
            leftSide = true;
            base.spriteRend.flipY = false;
        }
    }

    public override void Start () {
		
	}
	
	void Update () {
	    	
	}
}
