using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : Spawner
{
    [SerializeField] private Enemy _enemy;

    [SerializeField] private List<Transform> _pointsPatrol;

    protected override void Spawn()
    {
        Enemy enemy = Instantiate(_enemy, transform.position, Quaternion.identity, Container);
        enemy.Init(_pointsPatrol);
    }
}
