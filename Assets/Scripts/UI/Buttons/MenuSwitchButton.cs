using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MenuSwitchButton : MonoBehaviour
{
    [SerializeField] private MenuSwitcher _menuSwitcher;

    protected Button Button;

    private void Awake()
    {
        Button = GetComponent<Button>();
    }

    protected virtual void Start()
    {
        Button.onClick.AddListener(_menuSwitcher.Switch);
    }
}
