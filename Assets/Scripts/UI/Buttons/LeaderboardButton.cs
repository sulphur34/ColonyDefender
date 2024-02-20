using Agava.YandexGames;
using UnityEngine;

public class LeaderboardButton : MenuSwitchButton
{
    [SerializeField] MenuSwitcher _authorizationSwitcher;

    protected override void Start()
    {
        Button.onClick.AddListener(OpenLeaderboard);        
    }

    private void OpenLeaderboard()
    {
        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
            Switch();
            return;
        }
        
        _authorizationSwitcher.Switch();

        if (PlayerAccount.IsAuthorized == false)
            return;
    }
}
