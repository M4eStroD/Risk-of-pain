using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    [SerializeField] private float _speed;
    [SerializeField] private float _offset;

    private Vector3 _position;

    private void Start()
    {
        GetCoordinates();
    }

    private void Awake()
    {
        transform.position = _position;
    }

    private void LateUpdate()
    {
        GetCoordinates();

        transform.position = Vector3.Lerp(transform.position, _position, _speed * Time.deltaTime);
    }

    private void GetCoordinates()
    {
        _position = new Vector3()
        {
            x = _transform.position.x,
            y = _transform.position.y,
            z = _transform.position.z - _offset,
        };
    }
}
