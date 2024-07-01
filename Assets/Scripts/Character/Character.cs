using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    public event Action HealthChanged;

    protected private Rigidbody2D Rigidbody;
    protected private Animator Animator;

    protected float CurrentHealth;

    [SerializeField] protected float MaxHealth = 100f;
    [SerializeField] protected float Damage = 15f;
    [SerializeField] protected float AttackSpeed = 2f;

    public Mover Mover { get; protected set; }

    public float MaxHealthEntity => MaxHealth;
    public float CurrentHealthEntity => CurrentHealth;

    private void Start()
    {
        CurrentHealth = MaxHealth;

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
        if (CurrentHealth <= 0)
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
        CurrentHealth -= damage;

        HealthChanged?.Invoke();
    }
}
