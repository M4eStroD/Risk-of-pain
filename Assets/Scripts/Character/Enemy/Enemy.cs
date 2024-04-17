using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private EnemyMoverAI _enemyMover;

    public void Init(List<Transform> pointPatrol)
    {
        _enemyMover.SetRoute(pointPatrol);
    }
}
