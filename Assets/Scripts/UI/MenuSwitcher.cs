using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    [SerializeField] private Menu _activatedMenu;
    [SerializeField] private Menu _deactivatedMenu;

    public void Switch()
    {
        _deactivatedMenu.Deactivate();
        _activatedMenu.Activate();
    }
}
