using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : Enemy {

    private Vector3 _origin;
    private bool _attacking,_inRange = false;

    public float jumpHeight;
    public BoxCollider2D detectZone;


    public override void Start () {
        base.Start();
        detectZone.isTrigger = true;
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
                if (transform.position.y >= jumpHeight+_origin.y)
                {
                    base.enemyState = State.moving;
                }
                break;
            case State.moving:
                if (transform.position.y <= _origin.y)
                {
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
                break;
            case State.attack:
                transform.Translate(Vector3.up * Time.deltaTime);
                break;
            case State.moving:
                transform.Translate(Vector3.down * 1.1f * Time.deltaTime);
                break;
            default:
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

    void Update () {
		
	}
}
