using UnityEngine;

public class Player : Character
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PlayerMover _mover;

    private void Awake()
    {
        Mover = _mover;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _wallet.AddMoney(coin.CountCoin);
            coin.Collect();
        }
    }
}
