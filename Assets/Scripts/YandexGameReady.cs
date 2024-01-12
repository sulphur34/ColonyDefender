using Agava.YandexGames;
using UnityEngine;

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
