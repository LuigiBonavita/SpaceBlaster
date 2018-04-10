using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : EnemyBase
{
    public float Speed;
    public bool GoRight;
    public Transform RightLimit, LeftLimit;

    public override string GetID()
    {
        return "Cube";
    }

    public override int GetScore()
    {
        return 3;
    }
    public string ID
    {
        get
        {
            return "Cube";
        }
    }

    public int Life { get;  private set; }

    public override void MovementBehaviour()
    {
        if (transform.position.x > RightLimit.position.x)
            GoRight = false ;
        if (transform.position.x < LeftLimit.position.x)
            GoRight = true;

        if (GoRight)  transform.position += Vector3.right * Speed * Time.deltaTime;
        else transform.position += Vector3.left * Speed * Time.deltaTime; 
    }

    public override void ShootBehaviour()
    {
       
    }

    public void TakeDamage(int damage)
    {
        Life -= damage;  
    }

    //update
    private void FixedUpdate()
    {
        MovementBehaviour();
    }
}
