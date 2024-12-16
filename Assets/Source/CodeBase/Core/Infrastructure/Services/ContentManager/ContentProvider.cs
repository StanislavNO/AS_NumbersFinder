using Assets.Source.CodeBase.Core.Common.Configs;
using Assets.Source.CodeBase.Core.Infrastructure.Services.ContentManager;
using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Assets.Source.CodeBase.Core.Infrastructure.Services.Score
{
    internal class ContentProvider : IContentProvider, ILevelTarget
    {
        public event Action TargetChanged;

        private readonly List<Item> _contents;
        private readonly HashSet<string> _foundContentNames;
        private readonly Queue<Item> _randomContent;

        public string LevelTarget { get; private set; }

        public ContentProvider(LevelsContainer levelsContainer)
        {
            _contents = new List<Item>(levelsContainer.Bundle.Items);
            _foundContentNames = new HashSet<string>();
            _randomContent = new Queue<Item>();
        }

        public Item GetTarget()
        {
            if (_randomContent.Count == 0)
                RefillRandomContentQueue();

            Item target = _randomContent.Dequeue();
            _foundContentNames.Add(target.Name);
            LevelTarget = target.Name;
            TargetChanged?.Invoke();
            return target;
        }

        public Item GetContent()
        {
            if (_randomContent.Count == 0)
                RefillRandomContentQueue();

            return _randomContent.Dequeue();
        }

        private void RefillRandomContentQueue()
        {
            var availableContents = _contents
                .Where(item => !_foundContentNames.Contains(item.Name))
                .ToList();

            if (availableContents.Count == 0)
            {
                _foundContentNames.Clear();
                availableContents = new List<Item>(_contents);
            }

            foreach (var item in availableContents.OrderBy(_ => Random.Range(0, int.MaxValue)))
                _randomContent.Enqueue(item);

            if (_randomContent.Count == 0)
                throw new InvalidOperationException("Нет доступного контента для генерации!");
        }
    }
}