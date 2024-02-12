using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;

public class YandexLeaderboard : MonoBehaviour
{
    public const string LeaderboardName = "Leaderboard";

    [SerializeField] private LeaderboardView _leaderboardView;
    [SerializeField] private LeanPhrase _anonymousLeanPhrase;

    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new();
    private string _anonymousName;

    private void Awake()
    {
        _anonymousName = LeanLocalization.GetTranslationText(_anonymousLeanPhrase.name);
    }

    public void SetPLayerScore(int score)
    {
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

        if (PlayerAccount.IsAuthorized == false)
            return;

        Leaderboard.GetEntries(LeaderboardName, result =>
        {
            foreach (var entry in result.entries)
            {
                var rank = entry.rank;
                var score = entry.score;
                var name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = _anonymousName;

                _leaderboardPlayers.Add(new LeaderboardPlayer(rank, name, score));
            }

            _leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
        });
    }
}
