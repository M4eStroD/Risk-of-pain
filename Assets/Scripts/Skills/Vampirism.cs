using UnityEngine;

public class Vampirism : ActiveSkill
{
    [SerializeField] private float _damage = 0.2f;
    [SerializeField] private float _heal = 0.2f;

    [SerializeField] private VampirismArea _area;

    protected override void ApplyEffects()
    {
        Player player = Target as Player;

        foreach (var enemy in _area.GetEnemies())
        {
            enemy.TakeDamage(_damage);
            player.RestoreHealth(_heal);
        }
    }
}
