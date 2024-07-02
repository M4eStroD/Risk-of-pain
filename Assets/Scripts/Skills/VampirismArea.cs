using System.Collections.Generic;
using UnityEngine;

public class VampirismArea : MonoBehaviour
{
    [SerializeField] private Collider2D _area;

    private List<Enemy> _enemies = new List<Enemy>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            _enemies.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            _enemies.Remove(enemy);
    }

    public List<Enemy> GetEnemies()
    {
        List<Enemy> enemies = new List<Enemy>(_enemies.Count);
        
        _enemies.ForEach((item) => enemies.Add(item));

        return enemies;
    }
}
