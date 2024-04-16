using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public event Action AmountChanged;

    public int Money { get; private set; }

    public void AddMoney(int amount)
    {
        if (amount <= 0)
            return;

        Money += amount;

        AmountChanged?.Invoke();
    }
}
