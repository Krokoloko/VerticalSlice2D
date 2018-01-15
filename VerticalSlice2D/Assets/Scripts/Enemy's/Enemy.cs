using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    public float health;
    public GameObject physicsObj;
    public GameObject animationObj;
    public enum State {idle, moving, attack, dead};

    public SpriteRenderer spriteRend;
    public Collider2D collision;
    public Animator animator;
    public State enemyState;


    public virtual void Damage()
    {
        health--;
    }

    public virtual void Death()
    {
        if (health <= 0)
        {
            animator.SetTrigger("death");
        }
    }

    public virtual void Start () {
        collision = physicsObj.GetComponent<Collider2D>();
        animator = animationObj.GetComponent<Animator>();
        spriteRend = animationObj.GetComponent<SpriteRenderer>();
	}
	
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Damage();
        } 
    }

}
