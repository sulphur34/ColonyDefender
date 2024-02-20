using Agava.YandexGames;
using UnityEngine;

public class AuthorizationButton : MenuSwitchButton
{
    [SerializeField] private MenuSwitcher _mainMenuSwitcher;
    [SerializeField] private GameObject _waitingPanel;

    protected override void Start()
    {
        Button.onClick.AddListener(OpenAuthorization);
    }

    private void OpenAuthorization()
    {
        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
            Switch();
            return;
        }

        PlayerAccount.Authorize(OnSuccessCallback, OnErrorCallback);
        _waitingPanel.SetActive(true);

    }

    private void OnSuccessCallback()
    {
        _waitingPanel.SetActive(false);
        Switch();
    }

    private void OnErrorCallback(string errorMessage)
    {
        _waitingPanel.SetActive(false);
        _mainMenuSwitcher.Switch();
    }
}
