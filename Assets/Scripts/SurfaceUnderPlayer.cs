using UnityEngine;

public class SurfaceUnderPlayer : MonoBehaviour
{
    [SerializeField] private Transform _checkPoint;
    [SerializeField] private float _raycastLenght;

    public SurfaceType CurrentSurface { get; private set; }

    private void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(_checkPoint.position, Vector2.down, _raycastLenght);

        if (hitInfo == false)
        {
            CurrentSurface = SurfaceType.None;
            return;
        }

        if (hitInfo.transform.TryGetComponent(out Surface surface) == false)
        {
            CurrentSurface = SurfaceType.None;
            return;
        }

        if (surface.Type == CurrentSurface)
            return;

        CurrentSurface = surface.Type;
    }
}
