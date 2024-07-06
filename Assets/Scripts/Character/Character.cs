using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    [SerializeField] protected Health _health;

    [SerializeField] protected float Damage = 15f;
    [SerializeField] protected float AttackSpeed = 2f;

    protected private Rigidbody2D Rigidbody;
    protected private Animator Animator;

    public event Action HealthChanged;

    public Mover Mover { get; protected set; }

    public float MaxHealthEntity => _health.MaxHealth;
    public float CurrentHealthEntity => _health.CurrentHealth;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    protected virtual void OnEnable()
    {
        HealthChanged += Death;
    }

    protected virtual void OnDisable()
    {
        HealthChanged -= Death;
    }

    protected virtual void Attack(Character target)
    {
        target.TakeDamage(Damage);
    }

    protected virtual void Death()
    {
        if (_health.CurrentHealth <= 0)
            Destroy(gameObject);
    }

    protected void OnChangeHealth()
    {
        HealthChanged?.Invoke();
    }

    public Animator GetAnimator()
    {
        return Animator;
    }

    public void TakeDamage(float damage)
    {
        _health.Decrease(damage);

        HealthChanged?.Invoke();
    }
}
