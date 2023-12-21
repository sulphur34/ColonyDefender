using TMPro;
using UnityEngine;

public class TextSetter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _label;
    protected void SetText(int amount)
    {
        _label.text = amount.ToString();
    }

    protected void SetText(float amount)
    {
        _label.text = amount.ToString();
    }

    protected void SetColor(Color color)
    {
        _label.color = color;
    }
}
