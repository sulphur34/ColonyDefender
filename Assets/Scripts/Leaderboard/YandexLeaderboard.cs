using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;

public class YandexLeaderboard : MonoBehaviour
{
    private const string AnonymousName = "Anonymous";
    private const string LeaderboardName = "Leaderboard";

    [SerializeField] private LeaderboardView _leaderboardView;

    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new();

    public void SetPLayerScore(int score)
    {
        Debug.Log("Score value - " + score);

        if (PlayerAccount.IsAuthorized == false)
            return;

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result.score < score)
                Leaderboard.SetScore(LeaderboardName, score);
        });
    }

    public void Fill()
    {
        _leaderboardPlayers.Clear();

        Debug.Log("LeaderboardCleared");

        if (PlayerAccount.IsAuthorized == false)
            return;

        Debug.Log("LeaderboardStart fill");

        Leaderboard.GetEntries(LeaderboardName, result =>
        {
            foreach (var entry in result.entries)
            {
                var rank = entry.rank;
                var score = entry.score;
                var name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = AnonymousName;

                _leaderboardPlayers.Add(new LeaderboardPlayer(rank, name, score));

                Debug.Log("Player -" + rank + "" + name + "" + score);
            }

            _leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
        });
    }
}
