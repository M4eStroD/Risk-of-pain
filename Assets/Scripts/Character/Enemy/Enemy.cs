using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private EnemyMoverAI _mover;

    private void Awake()
    {
        Mover = _mover;    
    }

    public void Init(List<Transform> pointPatrol)
    {
        _mover.SetRoute(pointPatrol);
    }
}
