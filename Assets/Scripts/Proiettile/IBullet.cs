using UnityEngine;

/// <summary>
/// Interfaccia da implementre per ogni tipo di Bullet.
/// </summary>
public interface IBullet
{

    string ID { get; }
    GameObject gameObject { get; }
    IBulletState CurrentState { get; set; }
    object transform { get; }

    void Shoot(Vector3 _direction, float _force);

    event IBulletEvents.BulletEvent OnShoot;
    event IBulletEvents.BulletEvent OnDestroy;
    event IBulletEvents.EnemyHit OnEnemyHit;

}

/// <summary>
/// Classe che dichiara le tipologie di delegato utilizzate dall'interfaccia IBullet.
/// </summary>
public class IBulletEvents
{

    public delegate void BulletEvent(IBullet bullet);
    public delegate void EnemyHit(IEnemy enemy, IBullet bullet);

}

public enum IBulletState
{
    InPool,
    Destroying,
    InUse,
}