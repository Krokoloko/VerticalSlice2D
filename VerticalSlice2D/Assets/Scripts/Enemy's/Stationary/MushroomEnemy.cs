using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEnemy : Enemy {

    public float radius = 5;
    public GameObject projectileObject;
    public float timeCoolDown;

    private float _timer;
    private bool _leftSide, _attacked, _inRange;
    private GameObject _player;

    private void CheckSide()
    {
        if(transform.position.x < _player.transform.position.x)
        {
            _leftSide = true;
        }else
        {
            _leftSide = false;
        }
        base.spriteRend.flipX = _leftSide;
    }

    private void Shoot()
    {
        if (!base.animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot"))
        {
            base.animator.SetTrigger("shoot");
            _timer = Time.time;
            
        }
        if (base.animator.GetCurrentAnimatorStateInfo(0).length * 0.1 + _timer < Time.time)
        {
            if (_leftSide)
            {
                Instantiate(projectileObject, transform.position + new Vector3(1f, 0.8f, 0), transform.rotation);
            }
            else
            {
                Instantiate(projectileObject, transform.position + new Vector3(-1f, 0.8f, 0), transform.rotation);
            }
            base.animator.ResetTrigger("shoot");
            _attacked = true;
        }
    }

    private void EnemyRoutine()
    {
        switch (base.enemyState)
        {
            case State.attack:
                CheckSide();
                if (!_attacked)
                {
                    Shoot();
                    //Debug.Log("Begin time" + _timer);
                }
                if (_attacked)
                {
                    //Debug.Log("Timer" + Time.time);
                    if (Time.time - _timer > timeCoolDown)
                    {
                        _attacked = false;
                    }
                }
                
                break;
            case State.idle:
                _attacked = false;
                break;
            case State.dead:
                base.Death();
                break;
            default:
                Debug.Log("State is not defined. Setting it to idle");
                break;
        }
    }

    //The conditions to change its behaviour.
    private void RoutineSwitch()
    {
        CheckInRange();
        switch (base.enemyState)
        {
            case State.idle:
                if (_inRange)
                {
                    base.enemyState = State.attack;
                    base.animator.SetBool("inRange",true);
                }
                break;
            case State.attack:
                if (!_inRange)
                {

                    base.enemyState = State.idle;
                    base.animator.SetBool("inRange",false);
                }
                break;
            case State.dead:
                break;
            default:
                base.enemyState = State.idle;
                break;
        }
    }

    private void CheckInRange()
    {
        if ((_player.transform.position - gameObject.transform.position).sqrMagnitude < radius * radius)
        {
            _inRange = true;
        }
        else
        {
            _inRange = false;
        }
    }
    
    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _inRange = true;
        }
    }
    
   

    public override void Start () {
        base.Start();
        _player = GameObject.FindGameObjectWithTag("Player");
        _inRange = false;
	}
	
	void Update () {
        base.Death();
        EnemyRoutine();
        RoutineSwitch();
        Debug.Log(base.enemyState);
        Debug.Log(_leftSide);
	}
}
