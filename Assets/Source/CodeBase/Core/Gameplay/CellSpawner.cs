using Assets.Source.CodeBase.Core.Common.Configs;
using Assets.Source.CodeBase.Core.Gameplay;
using Assets.Source.CodeBase.Core.Infrastructure.Services.Factories;
using Assets.Source.CodeBase.Core.Infrastructure.Services.Initializers;
using System;
using System.Collections.Generic;

namespace Assets.Source.CodeBase.Core.Controllers
{
    internal class CellSpawner : ILevelCanceled
    {
        public event Action LastLevelPassed;

        private readonly GridFactory _gridFactory;
        private readonly LevelsContainer _levelsContainer;
        private readonly CellInitializer _cellInitializer;
        private readonly int _lastLevel;

        private List<Cell> _cells;
        private int _currentLevel;

        public CellSpawner(
            GridFactory gridFactory,
            LevelsContainer levelsContainer,
            CellInitializer cellInitializer)
        {
            _gridFactory = gridFactory;
            _levelsContainer = levelsContainer;
            _cellInitializer = cellInitializer;
            _cells = new List<Cell>();

            _currentLevel = 0;
            _lastLevel = _levelsContainer.Levels.Length;
        }

        public List<Cell> Spawn()
        {
            if (_currentLevel == _lastLevel)
            {
                LastLevelPassed?.Invoke();
                return null;
            }

            DisableActiveCells();

            int rows = _levelsContainer.Levels[_currentLevel].Row;
            int cols = _levelsContainer.Levels[_currentLevel].Column;

            _cells = _gridFactory.Get(rows, cols);
            _cellInitializer.InitContent(_cells);
            _currentLevel++;

            return _cells;
        }

        private void DisableActiveCells()
        {
            foreach (var cell in _cells)
                _gridFactory.Put(cell);
        }
    }
}