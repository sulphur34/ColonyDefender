using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Yandex
{
    public sealed class SDKInitializer : MonoBehaviour
    {
        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = false;
        }

        private IEnumerator Start()
        {
#if UNITY_EDITOR == false
                yield return YandexGamesSdk.Initialize(OnInitialized);
#else
            
                OnInitialized();
                yield return null;
            
#endif
        }

        private void OnInitialized()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}