using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Mover
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _distanceOffset = 0.2f;

    [SerializeField] private List<Transform> _route = new List<Transform>();

    [SerializeField] private int _currentIndexTarget = 0;

    [SerializeField] private Vector3 _currentTarget;
    [SerializeField] private Vector3 _myPosition; 

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
            _myPosition = transform.position;

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

        Rigidbody.velocity = new Vector3(direction.x, Rigidbody.velocity.y);
    }

    private void ChangeDirection()
    {
        _currentIndexTarget = ++_currentIndexTarget % _route.Count;

        _currentTarget = _route[_currentIndexTarget].position;

        DirectionMove = transform.position.x > _currentTarget.x ? 0 : 1;
    }

    private float GetDistance()
    {
        return Vector3.Distance(_myPosition, _currentTarget);
    }
}
