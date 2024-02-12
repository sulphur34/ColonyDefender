using UnityEngine;
using UnityEngine.UI;

public class EnemyPowerIcon : MonoBehaviour
{
    [SerializeField] private EnemyPowerLabel _powerLabel;
    [SerializeField] private FaidingUI _signalArrow;
    [SerializeField] private Image _enemyImage;

    public void Set(float powerValue)
    {
        _powerLabel.SetPowerValue(powerValue);
    }

    public void Show()
    {
        _powerLabel.Show();
        _signalArrow.Show();
        _enemyImage.enabled = true;
    }

    public void Hide()
    {
        _powerLabel.Hide();
        _signalArrow.Hide();
        _enemyImage.enabled = false;
    }
}
