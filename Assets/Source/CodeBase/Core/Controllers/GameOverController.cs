using Assets.Source.CodeBase.Core.Gameplay;
using Assets.Source.CodeBase.Core.Infrastructure.Services.TimeManager;
using Assets.Source.CodeBase.View.UI;
using System;

namespace Assets.Source.CodeBase.Core.Controllers
{
    internal class GameOverController : IDisposable
    {
        private readonly ILevelCanceled _levelCanceled;
        private readonly SceneSwitcher _sceneSwitcher;
        private readonly GameOverDisplay _gameOverDisplay;
        private readonly IPauseController _pauseController;

        public GameOverController(
            ILevelCanceled levelCanceled,
            SceneSwitcher sceneSwitcher,
            GameOverDisplay gameOverDisplay,
            IPauseController pauseController)
        {
            _levelCanceled = levelCanceled;
            _sceneSwitcher = sceneSwitcher;
            _gameOverDisplay = gameOverDisplay;
            _pauseController = pauseController;

            _levelCanceled.LastLevelPassed += OnLevelsCanceled;
            _gameOverDisplay.RestartButtonClicked += OnRestartClicked;
        }

        public void Dispose()
        {
            _levelCanceled.LastLevelPassed -= OnLevelsCanceled;
            _gameOverDisplay.RestartButtonClicked -= OnRestartClicked;
        }

        private void OnRestartClicked()
        {
            _sceneSwitcher.LoadGameAsync();
        }

        private void OnLevelsCanceled()
        {
            _gameOverDisplay.Show();
            _pauseController.Pause();
        }
    }
}