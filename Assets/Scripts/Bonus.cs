using System;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public event Action PickUp;

    public void Collect()
    {
        PickUp?.Invoke();
    }
}
