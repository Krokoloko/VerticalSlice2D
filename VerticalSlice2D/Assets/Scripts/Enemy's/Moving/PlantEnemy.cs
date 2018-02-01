using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : Enemy {

    private Vector3 _origin;
    private bool _attacking;
    private float _timer;
    public float cooldown, jumpHeight,jumpSpeed;


    //A function that changes the enemy to a different behaviour.
    //This function gives you to change things before you switch to a different state.
    private void RoutineSwitch()
    {
        switch (base.enemyState)
        {
            case State.idle:
                if (_timer + cooldown < Time.time)
                {
                    base.animator.SetTrigger("GoUp");
                    base.physicsObj.GetComponent<BoxCollider2D>().size = new Vector2(1.26f, 1.88f);
                    base.physicsObj.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
                    base.enemyState = State.attack;
                }
                break;
            case State.attack:
                if (transform.position.y >= jumpHeight+_origin.y)
                {
                    base.animator.ResetTrigger("GoUp");
                    base.animator.SetTrigger("Bite");
                    base.physicsObj.GetComponent<BoxCollider2D>().size = new Vector2(1.26f, 1.88f);
                    base.physicsObj.GetComponent<BoxCollider2D>().offset = new Vector2(-0.08f, 0f);
                    base.enemyState = State.moving;
                }
                break;
            case State.moving:
                if (transform.position.y <= _origin.y)
                {
                    _timer = Time.time;
                    
                    base.enemyState = State.idle;
                }
                break;
            default:
                base.enemyState = State.moving;
                break;
        }
    }

    private void EnemyRoutine()
    {
        switch (base.enemyState)
        {
            case State.idle:
                base.animator.ResetTrigger("Bite");

                break;
            case State.attack:
                transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
                break;
            case State.moving:
                transform.Translate(Vector3.down * jumpSpeed*0.55f * Time.deltaTime);
                break;
            default:
                break;
        }
    }

    public override void Start()
    {
        base.Start();
        _origin = transform.position;
        _timer = Time.time;
        Debug.Log(1 / (jumpSpeed / 2));
        base.animator.SetFloat("DownMultiplier",1 / (jumpSpeed*0.55f));
    }

    void Update () {
        EnemyRoutine();
        RoutineSwitch();
        Debug.Log(base.enemyState);
	}
}