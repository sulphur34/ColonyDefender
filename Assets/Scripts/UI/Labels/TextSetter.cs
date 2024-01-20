using TMPro;
using UnityEngine;

public class TextSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;

    public void Show()
    {
        _label.enabled = true;
    }

    public void Hide()
    {
        _label.enabled = false;
    }

    protected void SetText(int amount)
    {
        _label.text = amount.ToString();
    }

    protected void SetText(float amount)
    {
        _label.text = amount.ToString();
    }

    protected void SetText(string message)
    {
        _label.text = message;
    }

    protected void SetTextWithPrefix(string prefix, float amount)
    {
        string message = prefix + amount.ToString();
        SetText(message);
    }

    protected void SetColor(Color color)
    {
        _label.color = color;
    }
}
