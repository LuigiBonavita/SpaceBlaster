using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuocoNemico2 : MonoBehaviour
{

    public float ShootForza = 0.3f;
    public Transform PointShoot;
    public float Firerate = 0f;
    public bool Firing;

    BulletPoolManager BulletManager;

    // Use this for initialization
    void Start()
    {
        BulletManager = FindObjectOfType<BulletPoolManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Firerate = Firerate + Time.deltaTime;

        if (Firerate <= 0.6f && Firing == false)
        {

            //IBullet shootbullet = BulletPoolManager

            IBullet bulletToShoot = BulletPoolManager.GetBullet(BulletID: "1");
            bulletToShoot.transform.position = PointShoot.position;
            bulletToShoot.Shoot( new Vector3(1f,0f,1f), -ShootForza);
            Firing = true;
        }
        if (Firerate >= 1f)
        {
            Firerate = 0f;
            Firing = false;
        }
    }
}