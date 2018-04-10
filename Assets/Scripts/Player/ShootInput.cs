using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInput : MonoBehaviour
{
    [Header("Input Settings")]

    public KeyCode ShootKey = KeyCode.R;
    public float ShootForce = 0.3f;
    public Transform ShootPoint;
    public bool IsShooting = false;
    public float Timer = 0f;

    PlayerBulletPoolManager bulletManagers;

    // Use this for initialization
    void Start()
    {
        bulletManagers = FindObjectOfType<PlayerBulletPoolManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(ShootKey) && IsShooting == false)
        {
            TripleShoot();
            IsShooting = true;

        }
        if (IsShooting == true)
        {

            Timer = Timer + Time.deltaTime;
        }
        if (Timer >= 0.3f)
        {
            IsShooting = false;
            Timer = 0f;
        }

    }

    public void Shoot()
    {
        PlayerBullet bulletToShoot = bulletManagers.GetBullet();
        bulletToShoot.transform.position = ShootPoint.position;
        bulletToShoot.Shoot(transform.forward, ShootForce);
        bulletToShoot.OnDestroy += OnBulletDestroy;
    }

    public void TripleShoot()
    {
        PlayerBullet bulletToShoot = bulletManagers.GetBullet();
        bulletToShoot.transform.position = ShootPoint.position;
        bulletToShoot.Shoot(new Vector3(-1, 0, 1), ShootForce);
        PlayerBullet bulletToShoot1 = bulletManagers.GetBullet();
        bulletToShoot1.transform.position = ShootPoint.position;
        bulletToShoot1.Shoot(transform.forward, ShootForce);
        PlayerBullet bulletToShoot2 = bulletManagers.GetBullet();
        bulletToShoot2.transform.position = ShootPoint.position;
        bulletToShoot2.Shoot(new Vector3(1, 0, 1), ShootForce);
        bulletToShoot.OnDestroy += OnBulletDestroy;
        bulletToShoot1.OnDestroy += OnBulletDestroy;
        bulletToShoot2.OnDestroy += OnBulletDestroy;

    }

    public void OnBulletDestroy(PlayerBullet bullet)
    {

        bullet.OnDestroy -= OnBulletDestroy;

    }
}

