using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D Rigidbody;

    private float _tolerance = 0.005f;

    public SurfaceType SurfaceType { get; protected set; }
    public float DirectionMove { get; protected set; }
    public bool IsStanding { get { return Rigidbody.velocity.sqrMagnitude < _tolerance; } }

    private void Start()
    {
        SurfaceType = SurfaceType.Ground;
        DirectionMove = 0;
    }
}
