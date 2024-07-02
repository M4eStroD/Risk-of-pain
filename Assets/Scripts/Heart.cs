using UnityEngine;

public class Heart : Bonus
{
    [SerializeField] private int _countHealth = 15;

    public int CountHealth => _countHealth;
}
