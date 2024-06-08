using System.Collections.Generic;
using UnityEngine;

public class EnemyMoverAI : EnemyMover
{
    private const float DistanceOffset = 0.6f;

    [SerializeField] private List<Transform> _route = new List<Transform>();

    private Enemy _enemy;

    private Vector3 _currentTarget;
    private int _currentIndexTarget;


    private void FixedUpdate()
    {
        if (_currentTarget == null)
            return;

        if (_enemy.IsAttack == false)
            Move();
        else
            Pursue();
    }

    public void Init(List<Transform> route, Enemy enemy)
    {
        _route = route;
        _enemy = enemy;

        ChangeDirection();
    }

    private void Pursue()
    {
        _currentTarget = _enemy.Target.transform.position;

        SetDirectionToRotate();

        if (GetDistance() >= _enemy.DistanceAttack)
            MoveTowards(_currentTarget);
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

        SetDirectionToRotate();
    }

    private void SetDirectionToRotate()
    {
        DirectionMove = transform.position.x > _currentTarget.x ? 0 : 1;
    }

    private float GetDistance()
    {
        return Vector3.Distance(transform.position, _currentTarget);
    }
}
