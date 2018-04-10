using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPoolManager : MonoBehaviour
{

    Vector3 poolOutOfScreen = new Vector3(2000, 2000, 2000);

    public PlayerBullet PbulletPrefab;
    public int MaxBullet = 500;


    List<PlayerBullet> bullets = new List<PlayerBullet>();

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < MaxBullet; i++)
        {
            PlayerBullet bulletToAdd = Instantiate(PbulletPrefab);
            bulletToAdd.OnShoot += OnBulletShoot;
            bulletToAdd.OnDestroy += OnBulletDestroy;
            OnBulletDestroy(bulletToAdd);
            bullets.Add(bulletToAdd);
        }
    }

    private void OnDisable()
    {

        foreach (PlayerBullet bullet in bullets)
        {
            bullet.OnShoot -= OnBulletShoot;
            bullet.OnDestroy -= OnBulletDestroy;
        }
    }
    private void OnBulletDestroy(PlayerBullet bullet)
    {
        //move Bullets our offscreen
        bullet.transform.position = poolOutOfScreen;
    }

    private void OnBulletShoot(PlayerBullet bullet)
    {

    }

    public PlayerBullet GetBullet()
    {
        foreach (PlayerBullet bullet in bullets)
        {
            if (bullet.currentState == PlayerBullet.State.Pool)
                return bullet;
        }
        return null;
    }

}


