using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuocoNemico : MonoBehaviour {

    public float ShootForce = 0.3f;
    public Transform ShootPoint;
    public float FireRate = 0f;
    public bool IsFiring;

    BulletPoolManager bulletManager;

    // Use this for initialization
    void Start ()
    {
        bulletManager = FindObjectOfType<BulletPoolManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        FireRate = FireRate + Time.deltaTime;

        if (FireRate <= 0.6f && IsFiring == false)
        {
              Bullet bulletToShoot = BulletPoolManager.GetBullet();
              bulletToShoot.transform.position = PointShoot.position;
              bulletToShoot.Shoot( new Vector3(1f,0f,1f), -ShootForza);
              Firing = true;
        }
        if (FireRate >= 1f)
        {
            FireRate = 0f;
            IsFiring = false;
        }
    }

}
