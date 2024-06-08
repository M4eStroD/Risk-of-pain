using System;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    [SerializeField] private int _countHealth = 15;

    public event Action PickUp;

    public int CountHealth => _countHealth;

    public void Collect()
    {
        PickUp?.Invoke();
    }
}
