using UnityEngine;

public class PlayerMovement : Movement
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _forceJump = 15f;

    [SerializeField] private SurfaceUnderPlayer _currentSurface;

    private void FixedUpdate()
    {
        SurfaceType = _currentSurface.CurrentSurface;

        if (Input.GetButton("Horizontal"))
            Run();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Run()
    {
        DirectionMove = Input.GetAxisRaw("Horizontal");

        Vector3 direction = transform.right * _speed;

        _rigidbody.velocity = new Vector3(direction.x, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (SurfaceType == SurfaceType.Ground)
            _rigidbody.AddForce(transform.up * _forceJump, ForceMode2D.Impulse);
    }
}
