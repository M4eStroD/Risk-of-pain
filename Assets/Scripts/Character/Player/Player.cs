using System;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Weapon _weapon;

    public event Action OnDeath;

    private void Awake()
    {
        Mover = _mover;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _weapon.OnHit += Attack;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _weapon.OnHit -= Attack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _wallet.AddMoney(coin.CountCoin);
            coin.Collect();
        }
        else if (collision.TryGetComponent(out Heart healthBonus))
        {
            RestoreHealth(healthBonus.CountHealth);
            healthBonus.Collect();
        }
    }

    protected override void Attack(Character target)
    {
        if (target == null) return;

        base.Attack(target);
    }

    protected override void Death()
    {
        if (CurrentHealth <= 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }

    private void RestoreHealth(float countHealth)
    {
        CurrentHealth += countHealth;

        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;

        OnChangeHealth();  
    }
}
