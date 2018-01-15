using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEnemy : Enemy {

    public float radius = 5;
    public GameObject player;
    private CircleCollider2D _detectZone;
    private bool _inRange = false;
    private bool _leftSide;
    private bool _attacked;

    private void CheckSide()
    {
        if(transform.position.x < player.transform.position.x)
        {
            _leftSide = false;
            base.spriteRend.flipY = true;
        }else
        {
            _leftSide = true;
            base.spriteRend.flipY = false;
        }
    }

    private void EnemyRoutine()
    {
        switch (base.enemyState)
        {
            case State.attack:
                CheckSide();
                base.animator.SetBool("trig", _inRange);
                if (!_attacked)
                {

                    _attacked = false;
                }
                break;
            case State.idle:
                _attacked = false;
                base.animator.SetBool("trig", _inRange);
                break;
            case State.dead:
                base.animator.SetTrigger("dead");
                break;
            default:
                Debug.Log("State is not defined. Setting it to idle");
                break;
        }
    }
    private void RoutineSwitch()
    {
        switch (base.enemyState)
        {
            case State.idle:
                if (_inRange)
                {
                    base.enemyState = State.attack;
                }
                break;
            case State.attack:
                if (!_inRange)
                {
                    base.enemyState = State.idle;
                }
                break;
            case State.dead:
                break;
            default:
                base.enemyState = State.idle;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            _inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            _inRange = false;
        }
    }

    public override void Start () {
        base.Start();
        CheckSide();
        _detectZone = gameObject.GetComponent<CircleCollider2D>();
        _detectZone.isTrigger = true;
        _detectZone.radius = radius;
	}
	
	void Update () {
        base.Death();
        EnemyRoutine();
        RoutineSwitch();
	}
}
