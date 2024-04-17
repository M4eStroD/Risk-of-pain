using System.Collections.Generic;
using UnityEngine;

public class EnemyMoverAI : EnemyMover
{
    private const float DistanceOffset = 0.6f;

    [SerializeField] private List<Transform> _route = new List<Transform>();

    private int _currentIndexTarget = 0;
    private Vector3 _currentTarget;

    private void FixedUpdate()
    {
        if (_currentTarget == null)
            return;

        Move();
    }

    public void SetRoute(List<Transform> route)
    {
        _route = route;
        ChangeDirection();
    }

    private void Move()
    {
        if (GetDistance() <= DistanceOffset)
            ChangeDirection();
        else
            MoveTowards(_currentTarget);
    }

    private void ChangeDirection()
    {
        _currentIndexTarget = ++_currentIndexTarget % _route.Count;

        _currentTarget = _route[_currentIndexTarget].position;

        DirectionMove = transform.position.x > _currentTarget.x ? 0 : 1;
    }

    private float GetDistance()
    {
        return Vector3.Distance(transform.position, _currentTarget);
    }
}
