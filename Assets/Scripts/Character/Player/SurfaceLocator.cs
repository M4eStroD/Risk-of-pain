using UnityEngine;

public class SurfaceLocator : MonoBehaviour
{
    public SurfaceType CurrentSurface { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Surface surface))
            CurrentSurface = surface.Type;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Surface surface))
            if (surface.Type == SurfaceType.Ground)
                CurrentSurface = SurfaceType.None;
    }
}
