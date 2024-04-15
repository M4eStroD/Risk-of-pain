using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rigidbody;

    private float _tolerance = 0.005f;

    public SurfaceType SurfaceType { get; protected set; }
    public float DirectionMove { get; protected set; }
    public bool IsStanding { get { return _rigidbody.velocity.sqrMagnitude < _tolerance; } }

    private void Start()
    {
        SurfaceType = SurfaceType.Ground;
        DirectionMove = 0;
    }
}
