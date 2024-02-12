using UnityEngine;

public class LeaderboardMenu : Menu
{
    [SerializeField] private YandexLeaderboard _leaderboard;

    public override void Open()
    {
        base.Open();
        _leaderboard.Fill();
    }
}
