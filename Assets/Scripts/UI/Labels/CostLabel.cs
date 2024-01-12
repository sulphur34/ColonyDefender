using UnityEngine;

public class CostLabel : TextSetter
{
    private Purchase _purchase;

    private void Start()
    {
        SetLabelValue();
    }

    public void Initialize(Purchase purchase)
    {
        _purchase = purchase;
        _purchase.Completed += SetLabelValue;
    }
    
    protected virtual void SetLabelValue()
    {
        SetText(_purchase.CurrentCost);
    }
}
