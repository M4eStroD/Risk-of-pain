using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : Spawner
{
    [SerializeField] private EnemyObject _enemy;

    [SerializeField] private List<Transform> _pointsPatrol;

    protected override void Spawn()
    {
        EnemyObject enemy = Instantiate(_enemy, transform.position, Quaternion.identity, Container);
        enemy.Enemy.Init(_pointsPatrol);
    }
}
