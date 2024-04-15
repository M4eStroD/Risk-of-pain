using UnityEngine;

public class SpawnerCoin : Spawner
{
    [SerializeField] private Coin _coin;

    protected override void Spawn()
    {
        Instantiate(_coin, transform.position, Quaternion.identity, _container);
    }
}
