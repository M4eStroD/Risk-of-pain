using UnityEngine;

public class Coin : Bonus
{
    [SerializeField] private int _cointCoin = 1;

    public int CountCoin => _cointCoin;
}
