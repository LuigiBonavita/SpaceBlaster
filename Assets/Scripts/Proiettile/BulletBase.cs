using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour, IBullet
{

    private IBulletState _currentState = IBulletState.InPool;

    public IBulletState CurrentState
    {
        get { return _currentState; }
        set { _currentState = value; }
    }

    public string ID { get { return GetID(); } }

    object IBullet.transform
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    protected abstract string GetID();

    public event IBulletEvents.BulletEvent OnShoot;
    public event IBulletEvents.BulletEvent OnDestroy;
    public event IBulletEvents.EnemyHit OnEnemyHit;

    #region Events

    protected void InvokeOnShoot()
    {
        if (OnShoot != null)
            OnShoot(this);
    }

    protected void InvokeOnDestroy()
    {
        if (OnDestroy != null)
            OnDestroy(this);
    }

    protected void InvokeOnEnemyHitt(IEnemy enemy)
    {
        if (OnEnemyHit != null)
            OnEnemyHit(enemy, this);
    }
    #endregion

    #region Shoot 

    private void FixedUpdate()
    {
        OnFixedUpdate();
    }

    /// <summary>
    /// La base fa avanzare il proiettile in modo costante nella direzione di sparo con forza "force".
    /// </summary>
    protected virtual void OnFixedUpdate()
    {
        if (CurrentState == IBulletState.InUse)
        {
            transform.position += direction * force;
        }
    }

    protected Vector3 direction;
    protected float force;

    public void Shoot(Vector3 _direction, float _force)
    {
        CurrentState = IBulletState.InUse;
        if (OnShoot != null)
            OnShoot(this);
        direction = _direction;
        force = _force;
    }

    public void DestroyMe()
    {
        CurrentState = IBulletState.Destroying;
        if (OnDestroy != null)
            OnDestroy(this);
        DestroyVisualEffect();
    }

    public virtual void DestroyVisualEffect()
    {
        CurrentState = IBulletState.InPool;
    }

    #endregion

    #region Collision

    private void OnCollisionEnter(Collision collision)
    {
        OnCollisionDefaultBehaviour(collision);
    }

    protected virtual void OnCollisionDefaultBehaviour(Collision collision)
    {
        IEnemy enemyHit;

        if (CurrentState == IBulletState.InUse)
        {
            enemyHit = collision.collider.gameObject.GetComponent<IEnemy>();
            if (enemyHit != null)
            {
                InvokeOnEnemyHitt(enemyHit);
            }
            DestroyMe();
        }
    }

    #endregion
}