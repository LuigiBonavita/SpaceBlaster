using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public BulletEvent OnShoot;
    public BulletEvent OnDestroy;

    public EnemyHit OnEnemyHit;

    public State currentState = State.InPool;

    public void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == ("Muro"))
        {
            gameObject.transform.position = new Vector3(1000, 1000, 1000);
            currentState = State.InPool;
        }

        if (collider.gameObject.tag == ("Player"))
        {
            HealthScript.HealthValue -= 1;
            gameObject.transform.position = new Vector3(1000, 1000, 1000);
            currentState = State.InPool;
            if (HealthScript.HealthValue < 1)
            {
                collider.gameObject.transform.position = new Vector3(500, 500, 500);
                //Destroy(collider.gameObject);
            }

        }
        
    }

    private void Update()
    {
        if(currentState == State.InUse)
        {
            transform.position += direction * force;
        }
    }
    #region Shoot

    float force;
    Vector3 direction;
    public void Shoot(Vector3 _direction, float _force)
    {
        currentState = State.InUse;
        if(OnShoot != null)
           OnShoot(this);
        direction = _direction;
        force = _force;
    }
    #endregion

    #region API

    public void DestroyMe()
    {
        currentState = State.InPool;
        if(OnDestroy != null)
           OnDestroy(this);
    }

    #endregion

    
    #region Dichiarazioni Tipi

    public delegate void BulletEvent(Bullet bullet);

    public delegate void EnemyHit(EnemyHit enemy, Bullet bullet);

    public enum State
    {
        InPool,
        InUse, 
    }

    #endregion
}
