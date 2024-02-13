using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class TextResizer : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    private RectTransform rectTransform;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        rectTransform = GetComponent<RectTransform>();
    }

    protected void ResizeText()
    {
        float preferredWidth = textMeshPro.preferredWidth;
        float preferredHeight = textMeshPro.preferredHeight;

        rectTransform.sizeDelta = new Vector2(preferredWidth, preferredHeight);
    }
}
