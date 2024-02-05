using UnityEngine;

public class LeaderboardMenu : Menu
{
    [SerializeField] YandexLeaderboard _leaderboard;
    [SerializeField] EnhancementSystem _enhancementSystem;
    public override void Open()
    {
        base.Open();
        int score = Mathf.RoundToInt(_enhancementSystem.GameLevelValue);
        _leaderboard.SetPLayerScore(score);
        _leaderboard.Fill();
    }
}
