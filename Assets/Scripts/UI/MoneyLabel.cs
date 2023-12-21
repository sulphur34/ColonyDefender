using UnityEngine;

public class MoneyLabel : TextSetter
{
    [SerializeField] MoneySystem _moneySystem;

    private void Awake()
    {
        _moneySystem.AmountChanged += SetText;
    }
}
