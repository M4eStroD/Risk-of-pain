using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    protected private Rigidbody2D Rigidbody;
    protected private Animator Animator;

    [SerializeField] protected float Health = 100f;
    [SerializeField] protected float Damage = 15f;
    [SerializeField] protected float AttackSpeed = 2f;

    public Mover Mover { get; protected set; }

    private event Action OnTakeDamage;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    protected virtual void OnEnable()
    {
        OnTakeDamage += Death;
    }

    protected virtual void OnDisable()
    {
        OnTakeDamage -= Death;
    }

    protected virtual void Attack(Character target)
    {
        target.TakeDamage(Damage);
    }

    protected virtual void Death()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }

    public Animator GetAnimator()
    {
        return Animator;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;

        OnTakeDamage?.Invoke();
    }
}
