using UnityEngine;

public class PlayerMover : Mover
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _forceJump = 15f;

    [SerializeField] private SurfaceLocator _currentSurface;

    private string _directionInSpace = "Horizontal";

    private void FixedUpdate()
    {
        SurfaceType = _currentSurface.CurrentSurface;

        if (Input.GetButton(_directionInSpace))
            Run();
        else if (SurfaceType != SurfaceType.None)
            StopSliding();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Run()
    {
        DirectionMove = Input.GetAxisRaw(_directionInSpace);

        Vector3 direction = transform.right * _speed;

        Rigidbody.velocity = new Vector3(direction.x, Rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (SurfaceType != SurfaceType.None)
            Rigidbody.AddForce(transform.up * _forceJump, ForceMode2D.Impulse);
    }

    private void StopSliding()
    {
        Rigidbody.velocity = new Vector3(0, Rigidbody.velocity.y);
    }
}
