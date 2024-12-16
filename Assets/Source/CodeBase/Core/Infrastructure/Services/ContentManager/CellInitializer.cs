using Assets.Source.CodeBase.Core.Gameplay;
using Assets.Source.CodeBase.Core.Infrastructure.Services.Score;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.CodeBase.Core.Infrastructure.Services.Initializers
{
    internal class CellInitializer
    {
        private readonly IContentProvider _contentProvider;

        public CellInitializer(IContentProvider contentProvider)
        {
            _contentProvider = contentProvider;
        }

        public void InitContent(List<Cell> cells)
        {
            InitTarget(cells);

            foreach (Cell cell in cells)
            {
                if (cell.ItemId == null)
                    cell.Set(_contentProvider.GetContent());
            }
        }

        private void InitTarget(List<Cell> cells)
        {
            int targetIndex = Random.Range(0, cells.Count);

            cells[targetIndex].Set(_contentProvider.GetTarget());
        }
    }
}