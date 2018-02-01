using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
 
    public Animator animator;
    public enum bullet {none, mushroom, tullip};
    public bullet identity;

    private Vector3 _targetPosition;
    private Vector3 _traveling;


    public Vector3 TravelTo(Vector3 position)
    {
        Vector3 heading = _targetPosition - transform.position;
        Vector3 direction = heading / heading.magnitude;

        return direction;
    }

    private void Awake()
    {
        
    }

    void Start()
    {
        _targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        _traveling = TravelTo(_targetPosition);
        Debug.Log(_traveling);
        Destroy(this.gameObject, 10);
    }

    void Update () {
        switch (identity)
        {
            case bullet.mushroom:
                transform.Translate(_traveling * 2f * Time.deltaTime);
                break;
            case bullet.tullip:
                break;
            default:
                Debug.Log("Identity is not recognised.");
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Destroy(this.gameObject);
        }
    }
}
