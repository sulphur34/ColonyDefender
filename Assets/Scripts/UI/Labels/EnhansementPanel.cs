using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class EnhansementPanel : MonoBehaviour
{
    [SerializeField] private PurchaseButton _purchaseButton;
    [SerializeField] private EnhancementLeveLabel _enchancementLeveLabel;
    [SerializeField] private CostLabel _costLabel;
    [SerializeField] private Image _upgradeAvailableImage;
    [SerializeField] private ResourceSystem _resourceSystem;
    [SerializeField] private Enhancement _enhancement;
    [SerializeField] private Color _enableColor;
    [SerializeField] private Color _disableColor;

    private Purchase _purchase;
    private Image _image;

    public event Action EnhancementPurchased;

    private void Awake()
    {
        _purchase = GetComponent<Purchase>();
        _image = GetComponent<Image>();
        Initialize();
    }

    public void SetState()
    {
        if (_purchase.CanBuy)
        {
            _purchaseButton.Enable();
            _upgradeAvailableImage.enabled = true;
            _image.color = _enableColor;
        }
        else
        {
            _purchaseButton.Disable();
            _upgradeAvailableImage.enabled = false;
            _image.color = _disableColor;
        }

        _costLabel.SetLabelValue();
    }

    private void Initialize()
    {
        _purchase.Initialize(_resourceSystem, _enhancement);
        _purchaseButton.Initialize(_purchase);
        _enchancementLeveLabel.Initialize(_enhancement);
        _costLabel.Initialize(_purchase);
        _purchase.Completed += OnPurchaseCompleted;
    }
    
    private void OnPurchaseCompleted()
    {
        EnhancementPurchased?.Invoke();
    }
}
