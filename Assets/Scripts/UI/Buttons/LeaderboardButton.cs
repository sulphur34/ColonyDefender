using Agava.YandexGames;
using UnityEngine;

namespace UI.Buttons
{
    public class LeaderboardButton : MenuSwitchButton
    {
        [SerializeField] private MenuSwitcher _authorizationSwitcher;

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
}