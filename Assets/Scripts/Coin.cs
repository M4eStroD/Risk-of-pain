using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _cointCoin = 1;

    public int CountCoin => _cointCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            Destroy(gameObject);
    }
}
