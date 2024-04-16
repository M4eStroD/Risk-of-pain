using UnityEngine;

public class SpawnerCoin : Spawner
{
    [SerializeField] private Coin _coin;

    private Coin _currentCoin;

    protected override void Spawn()
    {
        _currentCoin = Instantiate(_coin, transform.position, Quaternion.identity, Container);
        Subscribe();
    }

    private void RemoveCoin()
    {
        Unsubscribe();
        Destroy(_currentCoin.gameObject);
    }

    private void Subscribe()
    {
        _currentCoin.PickUp += RemoveCoin;
    }

    private void Unsubscribe()
    {
        _currentCoin.PickUp -= RemoveCoin;
    }
}
