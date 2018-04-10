using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public BulletEvent OnShoot;
    public BulletEvent OnDestroy;

    public EnemyHit OnEnemyHit;

    public State currentState = State.Pool;

    public void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == ("Muro"))
        {

            gameObject.transform.position = new Vector3(1000, 1000, 1000);
            currentState = State.Pool;

        }

        if (collider.gameObject.tag == ("Nemico"))
        {
            ScoreScript.ScoreValue += 1;
            gameObject.transform.position = new Vector3(1000, 1000, 1000);
            currentState = State.Pool;
        }
    }

    private void Update()
    {
        if (currentState == State.Use)
        {
            transform.position += direction * force;
        }
    }
    #region Shoot

    float force;
    Vector3 direction;
    public void Shoot(Vector3 _direction, float _force)
    {
        currentState = State.Use;
        if (OnShoot != null)
            OnShoot(this);
        direction = _direction;
        force = _force;
    }
    #endregion

    #region API

    public void DestroyMe()
    {
        currentState = State.Pool;
        if (OnDestroy != null)
            OnDestroy(this);
    }

    #endregion


    #region Dichiarazioni Tipi

    public delegate void BulletEvent(PlayerBullet bullet);

    public delegate void EnemyHit(EnemyHit enemy, PlayerBullet bullet);

    public enum State
    {
        Pool,
        Use,
    }

    #endregion
}

