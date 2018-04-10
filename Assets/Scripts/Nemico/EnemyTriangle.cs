using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriangle : EnemyBase
{
    public float Speed;
    public bool GoRight;
    public Transform RightLimit, LeftLimit;

    public override string GetID()
    {
        return "Triangle";
    }

    public override int GetScore()
    {
        return 3;
    }
    public string ID
    {
        get
        {
            return "Triangle";        }
    }

    public int Life { get; set; }

    public int ScoreValue { get; set; }

    private void FixedUpdate()
    {
        MovementBehaviour();
    }

    public override void MovementBehaviour()
    {
        if (transform.position.x > RightLimit.position.x)
            GoRight = false;
        if (transform.position.x < LeftLimit.position.x)
            GoRight = true;

        if (GoRight) transform.position += new Vector3(1f,0,-0.1f) * Speed * Time.deltaTime;
        else transform.position += new Vector3(-1f,0,0.1f) * Speed * Time.deltaTime;
    }

    public override void ShootBehaviour()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int damage)
    {
        throw new System.NotImplementedException();
    }
}
