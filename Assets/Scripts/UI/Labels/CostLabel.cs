using UnityEngine;

public class CostLabel : TextSetter
{
    private Purchase _purchase;

    public void Initialize(Purchase purchase)
    {
        _purchase = purchase;
        _purchase.Completed += SetLabelValue;
    }
    
    public virtual void SetLabelValue()
    {
        SetText(_purchase.CurrentCost);
    }
}
