using UnityEngine;

public class Player : Character
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _wallet.AddMoney(coin.CountCoin);
            coin.Collect();
        }
    }
}
