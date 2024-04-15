using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _distanceOffset = 0.2f;

    [SerializeField] private List<Transform> _route = new List<Transform>();

    private int _currentIndexTarget = 0;

    private Vector3 _currentTarget;

    public void SetRoute(List<Transform> route)
    {
        _route = route;
        ChangeDirection();

        StartCoroutine(Movement());
    }

    private IEnumerator Movement()
    {
        while (true)
        {
            if (GetDistance() <= _distanceOffset)
                ChangeDirection();
            else
                Move();

            yield return null;
        }
    }

    private void Move()
    {
        Vector3 direction = transform.right * _speed;

        _rigidbody.velocity = new Vector3(direction.x, _rigidbody.velocity.y);
    }

    private void ChangeDirection()
    {
        if (_currentIndexTarget >= _route.Count)
            _currentIndexTarget = 0;

        _currentTarget = _route[_currentIndexTarget].position;

        DirectionMove = transform.position.x - _currentTarget.x > 0 ? 0 : 1;

        _currentIndexTarget++;
    }

    private float GetDistance()
    {
        return Vector3.Distance(_currentTarget, transform.position);
    }
}
