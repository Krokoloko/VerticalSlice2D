using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEnemy : Enemy {

    private float radius = 5;
    private SphereCollider _detectZone;
    private bool _inRange = false;
    private void EnemyRoutine()
    {
        switch (base.enemyState)
        {
            case State.attack:
                break;
            case State.idle:
                break;
            case State.dead:
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
        _detectZone = new SphereCollider();
        _detectZone.isTrigger = true;
        _detectZone.radius = radius;
	}
	
	void Update () {
        base.Death();
        EnemyRoutine();
        RoutineSwitch();
	}
}
