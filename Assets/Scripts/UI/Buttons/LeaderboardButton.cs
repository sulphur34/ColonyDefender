using Agava.YandexGames;

public class LeaderboardButton : MenuSwitchButton
{    
    protected override void Start()
    {
        Button.onClick.AddListener(OpenLeaderboard);
        base.Start();
    }

    private void OpenLeaderboard()
    {
        PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
            PlayerAccount.RequestPersonalProfileDataPermission();

        if (PlayerAccount.IsAuthorized == false)
            return;
    }
}
