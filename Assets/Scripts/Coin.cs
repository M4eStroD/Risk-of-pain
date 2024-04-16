using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _cointCoin = 1;

    public event Action PickUp;

    public int CountCoin => _cointCoin;

    public void Collect()
    {
        PickUp?.Invoke();
    }
}
