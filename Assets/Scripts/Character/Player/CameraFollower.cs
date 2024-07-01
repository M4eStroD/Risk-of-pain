using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] protected Transform _target;

    [SerializeField] protected float _speed;
    [SerializeField] protected float _offset;

    protected Vector3 _position;

    private void Awake()
    {
        transform.position = _position;
    }

    private void Start()
    {
        GetCoordinates();
    }

    protected virtual void LateUpdate()
    {
        GetCoordinates();

        transform.position = Vector3.Lerp(transform.position, _position, _speed * Time.deltaTime);
    }

    protected virtual void GetCoordinates()
    {
        _position = new Vector3()
        {
            x = _target.position.x,
            y = _target.position.y,
            z = _target.position.z - _offset,
        };
    }
}
