using UnityEngine;

public class LeaderboardMenu : Menu
{
    [SerializeField] Leaderboard _leaderboard;
    [SerializeField] LeaderboardView _view;
    [SerializeField] EnhancementSystem _enhancementSystem;
    public override void Open()
    {
        base.Open();
        int score = Mathf.RoundToInt(_enhancementSystem.GameLevelValue);
        _leaderboard.Player(score);
        _leaderboard.Fill();
    }

}
