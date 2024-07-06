using UnityEngine;

public class PlayerMover : Mover
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _forceJump = 15f;

    public void Run(float directionMove)
    {
        DirectionMove = directionMove;

        Vector3 direction = transform.right * _speed;

        Rigidbody.velocity = new Vector3(direction.x, Rigidbody.velocity.y);
    }

    public void Jump()
    {
        if (SurfaceType != SurfaceType.None)
            Rigidbody.AddForce(transform.up * _forceJump, ForceMode2D.Impulse);
    }

    public void StopSliding()
    {
        Rigidbody.velocity = new Vector3(0, Rigidbody.velocity.y);
    }
}
