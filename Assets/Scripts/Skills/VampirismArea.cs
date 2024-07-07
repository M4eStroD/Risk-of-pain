using System.Collections.Generic;
using System.Linq;
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

    public bool TryGetNearestEnemies(Vector3 position, out Enemy target)
    {
        target = null;

        if (_enemies.Count == 0)
            return false;

        target = _enemies[0];

        foreach (Enemy enemy in _enemies)
        {
            if (Vector3.Distance(enemy.transform.position, position) < 
                Vector3.Distance(target.transform.position, position))
                target = enemy;
        }

        return true;
    }
}
