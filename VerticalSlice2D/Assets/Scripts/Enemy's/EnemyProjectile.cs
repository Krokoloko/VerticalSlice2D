using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
 
    public Animator animator;
    public enum bullet {mushroom, tullip};
    public SpriteRenderer spriteRenderer;
    public Sprite projectileSprite;

    private Vector3 _targetPosition;

    private bullet identity;

    public Vector3 Travel(Vector3 position, float speed)
    {
        return Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }

    private void Awake()
    {
        _targetPosition = GameObject.FindGameObjectWithTag("player").transform.position;
    }

    void Start()
    {
               
    }

    void Update () {
        switch (identity)
        {
            case bullet.mushroom:
                transform.position = Travel(_targetPosition, 1f);
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
