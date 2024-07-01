using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    public Enemy Enemy => _enemy;

    private void OnEnable()
    {
        _enemy.HealthChanged += OnDeath;
    }

    private void OnDisable()
    {
        _enemy.HealthChanged -= OnDeath;
    }

    private void OnDeath()
    {
        if (_enemy.CurrentHealthEntity <= 0)
            Destroy(gameObject);
    }
}
