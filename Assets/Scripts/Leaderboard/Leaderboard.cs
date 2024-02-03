using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    private const string AnonymousName = "Anonymous";
    private const string LeaderboardName = "Leaderboard";

    [SerializeField] private LeaderboardView _leaderboardView;

    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new();
    
    public void Player(int score)
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

        Agava.YandexGames.Leaderboard.GetPlayerEntry(LeaderboardName, _ =>
        {
            Agava.YandexGames.Leaderboard.SetScore(LeaderboardName, score);
        });
    }

    public void Fill()
    {
        _leaderboardPlayers.Clear();

        if (PlayerAccount.IsAuthorized == false)
            return;

        Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, result =>
        {
            foreach (var entry in result.entries)
            {
                var rank = entry.rank;
                var score = entry.score;
                var name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = AnonymousName;

                _leaderboardPlayers.Add(new LeaderboardPlayer(rank, name, score));
            }

            _leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
        });
    }
}
