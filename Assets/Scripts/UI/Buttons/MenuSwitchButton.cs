using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class MenuSwitchButton : MonoBehaviour
    {
        protected Button Button;

        [SerializeField] private MenuSwitcher _menuSwitcher;

        protected virtual void Awake()
        {
            Button = GetComponent<Button>();
        }

        protected virtual void Start()
        {
            Button.onClick.AddListener(Switch);
        }

        protected void Switch()
        {
            _menuSwitcher.Switch();
        }
    }
}