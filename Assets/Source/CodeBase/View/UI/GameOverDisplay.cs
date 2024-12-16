using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.CodeBase.View.UI
{
    internal class GameOverDisplay : MonoBehaviour
    {
        public event Action RestartButtonClicked;

        [SerializeField] private Canvas _gameOverPanel;
        [SerializeField] private Button _restartButton;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClick);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        }

        public void Show()
        {
            _gameOverPanel.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _gameOverPanel.gameObject.SetActive(false);
        }

        private void OnRestartButtonClick()
        {
            _restartButton.interactable = false;
            RestartButtonClicked?.Invoke();
        }
    }
}