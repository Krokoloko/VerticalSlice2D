using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
 
    public Animator animator;
    public enum bullet {none, mushroom, tullip};
    public SpriteRenderer spriteRenderer;
    public Sprite projectileSprite;
    public bullet identity;

    private Vector3 _targetPosition;
    private Vector3 _traveling;


    public Vector3 Travel(Vector3 position, float speed)
    {
        return Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }

    private void Awake()
    {
        _targetPosition = GameObject.FindGameObjectWithTag("player").transform.position;
        _traveling = Travel(_targetPosition, 1f);
        Debug.Log(_traveling);
    }

    void Start()
    {
               
    }

    void Update () {
        switch (identity)
        {
            case bullet.mushroom:
                transform.Translate(_traveling);
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
            Destroy(gameObject);
        }
    }
}
