using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private EnemyMoverAI _mover;

    [SerializeField] private float _distanceAttack;

    public Player Target {  get; private set; }
    public bool IsAttack {  get; private set; }
    public float DistanceAttack => _distanceAttack;

    private bool _isAttackReady = true;

    private void Awake()
    {
        Mover = _mover;    
    }

    private void Update()
    {
        if (Target == null)
            return;

        if (Vector3.Distance(transform.position, Target.transform.position) > _distanceAttack)
            return;

        Attack(Target);
    }

    protected override void Attack(Character target)
    {
        if (_isAttackReady)
        {
            _isAttackReady = false;

            base.Attack(target);
            StartCoroutine(CooldownAttack());
        }
    }

    public void Init(List<Transform> pointPatrol)
    {
        _mover.Init(pointPatrol, this);
    }

    public void SetTarget(Player target)
    {
        if (Target == null)
            Target = target;

        IsAttack = true;
    }

    private IEnumerator CooldownAttack()
    {
        yield return new WaitForSeconds(AttackSpeed);
        _isAttackReady = true;
    }
}
