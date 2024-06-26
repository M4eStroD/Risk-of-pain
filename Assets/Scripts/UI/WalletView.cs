using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _amountView;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.AmountChanged += DisplayAmount;
    }

    private void OnDisable()
    {
        _wallet.AmountChanged -= DisplayAmount;
    }

    public void DisplayAmount()
    {
        _amountView.text = _wallet.Money.ToString();
    }
}
