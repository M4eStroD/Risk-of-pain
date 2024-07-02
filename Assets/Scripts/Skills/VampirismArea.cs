using System.Collections.Generic;
using UnityEngine;

public class VampirismArea : MonoBehaviour
{
    [SerializeField] private Collider2D _area;

    public List<Enemy> Enemies { get; private set; } = new List<Enemy>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            Enemies.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            Enemies.Remove(enemy);
    }
}
