using Agava.YandexGames;
using UnityEngine;

namespace Utils
{
    public class YandexGameReady : MonoBehaviour
    {
        private void Awake()
        {
            OnCallGameReadyButtonClick();
        }

        private void OnCallGameReadyButtonClick()
        {
            YandexGamesSdk.GameReady();
        }
    }
}