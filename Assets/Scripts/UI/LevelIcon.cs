using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelIcon : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;

    public void SetColor(Color color)
    {
        _image.color = color;
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}
