using Agava.YandexGames;
using UnityEngine;

namespace Utils
{
    public class YandexGameReady : MonoBehaviour
    {
        private void Awake()
        {
            OnCallGameReadyButtonClick();
            DontDestroyOnLoad(gameObject);
        }

        private void OnCallGameReadyButtonClick()
        {
            YandexGamesSdk.GameReady();
        }
    }
}