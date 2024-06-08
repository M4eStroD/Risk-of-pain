using UnityEngine;

public class SpawnerHealth : Spawner
{
    [SerializeField] private HealthBonus Health;

    private HealthBonus _currentHealthBonus;

    protected override void Spawn()
    {
        _currentHealthBonus = Instantiate(Health, transform.position, Quaternion.identity, Container);
        Subscribe();
    }

    private void RemoveCoin()
    {
        Unsubscribe();
        Destroy(_currentHealthBonus.gameObject);
    }

    private void Subscribe()
    {
        _currentHealthBonus.PickUp += RemoveCoin;
    }

    private void Unsubscribe()
    {
        _currentHealthBonus.PickUp -= RemoveCoin;
    }
}
