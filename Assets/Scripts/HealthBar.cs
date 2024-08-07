using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character _entity;

    [SerializeField] private Slider _healthBar;

    public Character Entity => _entity;
    public Slider Bar => _healthBar;

    private void OnEnable()
    {
        _entity.HealthChanged += ChangeBar;
    }

    private void OnDisable()
    {
        _entity.HealthChanged -= ChangeBar;
    }

    protected virtual void ChangeBar()
    {
        float reductionFactor = 100;

        _healthBar.value = GetPercentBar() / reductionFactor;
    }

    protected float GetPercentBar()
    {
        float hundredProcent = 100;

        return _entity.CurrentHealthEntity * hundredProcent / _entity.MaxHealthEntity;
    }
}
