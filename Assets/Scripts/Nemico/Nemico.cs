using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nemico : MonoBehaviour {
    public int ScoreValue;
    public int Life;
    public bool IsAlive = true;

	public void TakeDamage(int Damage = 1)
    {
        Life = 0;
        IsAlive = false;
    }
}
