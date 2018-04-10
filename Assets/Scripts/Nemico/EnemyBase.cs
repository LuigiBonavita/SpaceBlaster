using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    public string ID
    {
        get { return GetID(); }
    }
    public int ScoreValue{ get; set; }
    
    public void FixedUpdate()
    {
        MovementBehaviour();
        ShootBehaviour();
    }
    public int Life { get; private set; }

    public abstract void MovementBehaviour();
    public abstract void ShootBehaviour();

    public virtual void TakeDamage(int damage)
    {
        Life -= damage;
    }

    //dichiaro l'utilizzatore
    public abstract string GetID();

    public abstract int GetScore();
}
