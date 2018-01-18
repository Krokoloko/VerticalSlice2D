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
<<<<<<< HEAD
    }

    public override void Start () {
		
	}
	
	void Update () {
	    	
	}
=======
        base.spriteRend.flipX = leftSide;
    }

    public override void Start () {
        base.Start();
        leftSide = base.RandomBool();
        base.enemyState = State.moving;
        

    }

    private void EnemyRoutine()
    {
        switch (base.enemyState)
        {
            case State.moving:
                if (leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * walkingSpeed);
                }
                else
                {
                    transform.Translate(Vector3.right * Time.deltaTime * walkingSpeed);
                }
                break;
            case State.dead:
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

    private void RoutineSwitch()
    {
        switch (base.enemyState)
        {
            case State.moving:
                CheckSide();
                break;
            case State.idle:
                base.enemyState = State.moving;
                break;
        }
    }

    void Update () {
        EnemyRoutine();
        RoutineSwitch();
        Debug.Log(leftSide);
        
    }
>>>>>>> f97fc0561867521fd39f9d6b3428c5ae1101154b
}
