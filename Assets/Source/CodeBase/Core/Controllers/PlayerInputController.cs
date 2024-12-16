using Assets.Source.CodeBase.Core.Gameplay;
using Assets.Source.CodeBase.Core.Infrastructure.Services.AnimatorController;
using Assets.Source.CodeBase.Core.Infrastructure.Services.ContentManager;
using Assets.Source.CodeBase.Core.Infrastructure.Services.InputService;
using Assets.Source.CodeBase.Core.Infrastructure.Services.TimeManager;
using System;
using UnityEngine;

namespace Assets.Source.CodeBase.Core.Controllers
{
    internal class PlayerInputController : IDisposable, ILevelCompletion
    {
        public event Action LevelTargetComplied;
        public event Action LevelTargetClicked;

        private readonly IInputService _inputService;
        private readonly IAnimationService _animationService;
        private readonly ILevelTarget _score;
        private readonly IPauseController _pauseController;

        public PlayerInputController(
            IInputService inputService,
            IAnimationService animationService,
            ILevelTarget levelTarget,
            IPauseController pauseController)
        {
            _inputService = inputService;
            _animationService = animationService;
            _score = levelTarget;
            _pauseController = pauseController;

            _inputService.Clicked += OnPlayerClick;
        }

        public void Dispose()
        {
            _inputService.Clicked -= OnPlayerClick;
        }

        private void OnPlayerClick(Vector2 clickPosition)
        {
            if (_pauseController.IsGame == false)
                return;

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.TryGetComponent(out Cell cell))
                SelectCell(cell);
        }

        private void SelectCell(Cell cell)
        {
            if (cell.ItemId != _score.LevelTarget)
                _animationService.Vibration(cell.ContentTransform);
            else
            {
                _pauseController.Pause();
                LevelTargetClicked?.Invoke();
                _animationService.Rotation(cell.ContentTransform, LevelTargetComplied);
                _animationService.SpawnParticle(cell.ContentTransform.position);
            }
        }
    }
}