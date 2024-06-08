using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float SpeedPhysicsFactor = 50f;

    [SerializeField] private float _speedBullet;
    [SerializeField] private Rigidbody2D _rigidbody;

    public event Action<Bullet, Character> OnCrashed;

    private Vector3 _direction;
    private float _totalSpeed;

    private void FixedUpdate()
    {
        if (_direction != null)
            MoveTowards();
    }

    public void SetDirection(Vector3 direction)
    {
        _totalSpeed = _speedBullet * SpeedPhysicsFactor * Time.fixedDeltaTime;
        _direction = (direction - transform.position).normalized;
    }

    private void MoveTowards()
    {
        _rigidbody.velocity = new Vector3(_direction.x * _totalSpeed, _direction.y * _totalSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            OnCrashed?.Invoke(this, enemy);
        }
        else if (collision.TryGetComponent(out Surface endMap))
        {
            if (endMap.Type == SurfaceType.Block)
            {
                OnCrashed?.Invoke(this, null);
            }
        }
    }
}
