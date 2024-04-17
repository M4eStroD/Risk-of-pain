using UnityEngine;

public class EnemyMover : Mover
{
    private const float SpeedPhysicsFactor = 50f;

    [SerializeField] private float _speed = 1f;

    private float _totalSpeed;

    public void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;

        _totalSpeed = _speed * SpeedPhysicsFactor * Time.fixedDeltaTime;

        Rigidbody.velocity = new Vector3(direction.x * _totalSpeed, Rigidbody.velocity.y);
    }
}
