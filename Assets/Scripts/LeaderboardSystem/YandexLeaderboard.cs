using System.Collections.Generic;
using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

namespace LeaderboardSystem
{
    public class YandexLeaderboard : MonoBehaviour
    {
        private const string LeaderboardName = "Leaderboard";

        private readonly List<LeaderboardPlayer> _leaderboardPlayers = new List<LeaderboardPlayer>();

        [SerializeField] private LeaderboardView _leaderboardView;
        [SerializeField] private LeanPhrase _anonymousLeanPhrase;

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
}