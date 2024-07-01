using UnityEngine;

public class CanvasHealthBar : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    private void Start()
    {
        _canvas.worldCamera = Camera.main;
    }
}
