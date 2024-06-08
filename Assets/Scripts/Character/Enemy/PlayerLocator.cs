using UnityEngine;

public class PlayerLocator : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            _enemy.SetTarget(player);
    }
}
