using Assets.Source.CodeBase.Core.Common.Configs;
using Assets.Source.CodeBase.Core.Gameplay;
using Assets.Source.CodeBase.Core.Infrastructure.Services.Pool;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.CodeBase.Core.Infrastructure.Services.Factories
{
    public class GridFactory
    {
        private readonly Cell _prefab;
        private readonly Pool<Cell> _pool;

        private readonly Vector2 _cellSize;
        private readonly List<Cell> _activeCells;
        private readonly GameObject _gridParentPoint;

        public GridFactory(PrefabsContainer prefabsContainer)
        {
            _prefab = prefabsContainer.Cell;
            _pool = new Pool<Cell>(Create);

            _cellSize = _prefab.GetComponent<Renderer>().bounds.size;
            _activeCells = new List<Cell>();
            _gridParentPoint = new GameObject(nameof(_gridParentPoint));
        }

        public List<Cell> Get(int rows, int columns)
        {
            float gridWidth = columns * _cellSize.x;
            float gridHeight = rows * _cellSize.y;
            int centerOffsetFactor = 2;

            Vector3 gridOffset = new Vector3(
                -gridWidth / centerOffsetFactor + _cellSize.x / centerOffsetFactor,
                gridHeight / centerOffsetFactor - _cellSize.y / centerOffsetFactor, 0);

            _activeCells.Clear();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Vector3 position = new Vector3(
                        j * _cellSize.x, -i * _cellSize.y, 0) + gridOffset;

                    Cell cell = _pool.Get();
                    cell.Transform.position = position;
                    cell.Transform.SetParent(_gridParentPoint.transform, false);
                    _activeCells.Add(cell);
                }
            }

            return _activeCells;
        }

        public void Put(Cell cell) =>
            _pool.Put(cell);

        private Cell Create() =>
            Object.Instantiate(_prefab);
    }
}