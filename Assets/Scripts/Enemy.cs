using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private EnemyMovement _movement;

    public void Init(List<Transform> pointPatrol)
    {
        _movement.SetRoute(pointPatrol);
    }
}
