using System.Collections;
using UnityEngine;

public class Vampirism : ActiveSkill
{
    [SerializeField] private float _damage = 5;
    [SerializeField] private float _damageInterval = 1f;

    [SerializeField] private float _heal = 5;

    [SerializeField] private VampirismArea _area;

    protected override void Terminate()
    {
        base.Terminate();

        _area.gameObject.SetActive(false);
    }

    protected override IEnumerator TimerDuration()
    {
        float intervalTime = 0.5f;
        float effectInterval = 0f;

        while (_currentDurationTime <= DurationTime)
        {
            _currentDurationTime += intervalTime;

            if (effectInterval >= _damageInterval)
            {
                effectInterval = 0f;
                ApplyEffects();
            }
            else
            {
                effectInterval += intervalTime;
            }

            yield return new WaitForSeconds(intervalTime);
        }

        _currentDurationTime = 0f;

        Terminate();
        StartCoroutine(TimerRecovery());
    }

    public override bool TryUse(Character target)
    {
        if (base.TryUse(target))
        {
            _area.gameObject.SetActive(true);

            return true;
        }

        return false;
    }

    private void ApplyEffects()
    {
        Player player = Target as Player;

        foreach (var enemy in _area.Enemies)
        {
            enemy.TakeDamage(_damage);
            player.RestoreHealth(_heal);
        }
    }
}
