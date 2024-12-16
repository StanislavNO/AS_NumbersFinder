using Assets.Source.CodeBase.Core.Infrastructure.Services.SceneSwitcher;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.CodeBase.Core
{
    public class SceneSwitcher
    {
        public event Action LoadStarting;
        public event Action LoadCanceled;

        public async void LoadGameAsync()
        {
            LoadStarting?.Invoke();
            await LoadSceneAsync();
            LoadCanceled?.Invoke();
        }

        private async Task LoadSceneAsync()
        {
            AsyncOperation asyncLoad = SceneManager
                .LoadSceneAsync((int)SceneNames.Game);

            while (!asyncLoad.isDone)
                await Task.Yield();
        }
    }
}