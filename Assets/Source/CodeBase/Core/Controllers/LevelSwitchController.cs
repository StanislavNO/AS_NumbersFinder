using Assets.Source.CodeBase.Core.Infrastructure.Services.TimeManager;
using System;

namespace Assets.Source.CodeBase.Core.Controllers
{
    internal class LevelSwitchController : IDisposable
    {
        private readonly ILevelCompletion _levelCompletion;
        private readonly CellSpawner _cellSpawner;
        private readonly IPauseController _pauseController;

        public LevelSwitchController(
            ILevelCompletion levelCompletion,
            CellSpawner cellSpawner,
            IPauseController pauseController)
        {
            _levelCompletion = levelCompletion;
            _cellSpawner = cellSpawner;
            _pauseController = pauseController;

            _levelCompletion.LevelTargetComplied += OnLevelComplied;
        }

        public void Dispose()
        {
            _levelCompletion.LevelTargetComplied -= OnLevelComplied;
        }

        private void OnLevelComplied()
        {
            if (_cellSpawner.Spawn() != null)
                _pauseController.UnPause();
        }
    }
}