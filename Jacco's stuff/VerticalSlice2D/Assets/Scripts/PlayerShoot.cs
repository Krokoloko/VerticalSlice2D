using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public Transform right;
    [SerializeField]
    public float bulletSpeed = 25f;
    private float _Firerate = 0.15f;
    private float _Nextfire = 0.0f;
   
  


    //shooting	
    public void Shoot()
    {
        if ( Time.time > _Nextfire)
        {
            _Nextfire = Time.time + _Firerate;
         
            GameObject bullethandler;
            bullethandler = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);

            Rigidbody rigidbody;
            rigidbody = bullethandler.GetComponent<Rigidbody>();

            rigidbody.AddForce((right.position - transform.position) * bulletSpeed);

            Destroy(bullethandler, 1.0f);
        }
    }
    
}
