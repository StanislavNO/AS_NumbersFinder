using Assets.Source.CodeBase.Core.Controllers;
using Assets.Source.CodeBase.Core.Infrastructure.Services.AnimatorController;
using Assets.Source.CodeBase.Core.Infrastructure.Services.ContentManager;
using Assets.Source.CodeBase.View.UI;
using System;
using Zenject;

namespace Assets.Source.CodeBase.Core
{
    internal class ViewController : IDisposable, IInitializable
    {
        private readonly ITargetDisplay _targetDisplay;
        private readonly IAnimationService _animationService;
        private readonly ILevelTarget _levelTarget;

        public ViewController(
            ITargetDisplay targetDisplay,
            IAnimationService animationService,
            ILevelTarget levelTarget)
        {
            _targetDisplay = targetDisplay;
            _animationService = animationService;
            _levelTarget = levelTarget;

            _levelTarget.TargetChanged += OnTargetChanged;
        }

        public void Dispose()
        {
            _levelTarget.TargetChanged -= OnTargetChanged;
        }

        public void Initialize()
        {
            _targetDisplay.CanvasGroup.gameObject.SetActive(true);
            _animationService.FadeIn(_targetDisplay.CanvasGroup);
        }

        private void OnTargetChanged()
        {
            _targetDisplay.ShowTarget(_levelTarget.LevelTarget);
        }
    }
}