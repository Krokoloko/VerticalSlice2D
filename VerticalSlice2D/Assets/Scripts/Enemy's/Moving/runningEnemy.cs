using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningEnemy : Enemy {

    public float walkingSpeed;
    public bool leftSide;

    public Transform firstPoint;
    public Transform secondPoint;

    //To check which side the sprite has to face to
    private void CheckSide()
    {
        if (leftSide)
        {
            if (firstPoint.position.x >= transform.position.x)
            {
                leftSide = false;
            }
        }
        else
        {
            if (secondPoint.position.x <= transform.position.x)
            {
                leftSide = true;
            }
        }
        base.spriteRend.flipX = leftSide;

    }

    public override void Start()
    {
        base.Start();
        leftSide = base.RandomBool();
        base.enemyState = State.moving;


    }

    //The usual state actions
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

    //The conditions to change its behaviour.
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

    void Update()
    {
        EnemyRoutine();
        RoutineSwitch();
    }
}
