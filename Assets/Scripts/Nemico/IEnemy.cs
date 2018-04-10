using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    //info generiche
    string ID { get; }
    // i nemici saranno gameobj
    GameObject gameObject { get; }
    int Life { get; }
    int ScoreValue { get; }





    //movimento generico
    void MovementBehaviour();
    //sparo generico
    void ShootBehaviour();
    //danno generico
    void TakeDamage(int damage);

}
