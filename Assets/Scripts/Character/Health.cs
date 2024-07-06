using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Increase(float value)
    {
        _currentHealth += value;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }

    public void Decrease(float value)
    {
        _currentHealth -= value;
    }
}
