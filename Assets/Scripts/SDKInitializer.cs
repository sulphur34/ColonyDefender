using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Yandex
{
    public sealed class SDKInitializer : MonoBehaviour
    {
        public object ScensesNames { get; private set; }

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = false;
        }

        private IEnumerator Start()
        {
            yield return YandexGamesSdk.Initialize(OnInitialized);
        }

        private void OnInitialized() 
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}