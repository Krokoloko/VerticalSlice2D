using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : Enemy {

    private BoxCollider2D _detectZone;

    public override void Start () {
        base.Start();
	}

    private void RoutineSwitch()
    {
        switch (base.enemyState)
        {
            case State.idle:
            /*    if ()
                {

                }*/
                break;
            case State.attack:
                break;
            case State.moving:
                break;
            default:
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
                break;
            case State.moving:
                break;
            default:
                break;
        }
    }
	void Update () {
		
	}
}
