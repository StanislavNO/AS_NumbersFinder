using Assets.Source.CodeBase.Core.Gameplay;
using Assets.Source.CodeBase.Core.Infrastructure.Services.AnimatorController;
using Assets.Source.CodeBase.Core.Infrastructure.Services.TimeManager;
using Assets.Source.CodeBase.View.UI;
using System.Collections.Generic;
using Zenject;

namespace Assets.Source.CodeBase.Core.Controllers
{
    internal class GameStarter : IInitializable
    {
        private readonly CellSpawner _cellSpawner;
        private readonly IAnimationService _animationService;
        private readonly IPauseController _pauseController;

        public GameStarter(
            CellSpawner cellSpawner,
            IAnimationService animationService,
            IPauseController pauseController)
        {
            _cellSpawner = cellSpawner;
            _animationService = animationService;
            _pauseController = pauseController;
        }

        public void Initialize()
        {
            _pauseController.UnPause();

            List<Cell> cells = _cellSpawner.Spawn();

            foreach (Cell cell in cells)
                _animationService.ShowBounds(cell.transform);
        }
    }
}