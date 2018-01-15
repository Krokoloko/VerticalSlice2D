using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour {

    public int damage = 1;

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Target")
        {
            PlayerHealth.health -= damage;
            print("hit");
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (PlayerHealth.health <= 0)
        {
            PlayerHealth.health = 0;    
        }
	}
}
