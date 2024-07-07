using UnityEngine;

public class Vampirism : ActiveSkill
{
    [SerializeField] private float _damage = 0.2f;
    [SerializeField] private float _heal = 0.2f;

    [SerializeField] private VampirismArea _area;

    [SerializeField] private Player _player;

    protected override void ApplyEffects()
    {
        if (_area.TryGetNearestEnemies(_player.transform.position, out Enemy target) == false)
            return;

        if (target.CurrentHealthEntity < _damage)
            _player.RestoreHealth(_heal - target.CurrentHealthEntity);
        else
            _player.RestoreHealth(_heal);

        target.TakeDamage(_damage);
    }
}
