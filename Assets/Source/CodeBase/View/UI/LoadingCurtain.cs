using Assets.Source.CodeBase.Core;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Source.CodeBase.View.UI
{
    public class LoadingCurtain : MonoBehaviour
    {
        public CanvasGroup Curtain;

        private SceneSwitcher _sceneSwitcher;

        [Inject]
        private void Construct(SceneSwitcher sceneSwitcher)
        {
            _sceneSwitcher = sceneSwitcher;
            DontDestroyOnLoad(this);
        }

        private void Awake()
        {
            _sceneSwitcher.LoadStarting += Show;
            _sceneSwitcher.LoadCanceled += DoFadeInAsync;
        }

        private void OnDestroy()
        {
            _sceneSwitcher.LoadStarting -= Show;
            _sceneSwitcher.LoadCanceled -= DoFadeInAsync;
        }

        public void Show()
        {
            gameObject.SetActive(true);
            Curtain.alpha = 1f;
        }

        public async void DoFadeInAsync()
        {
            float fadeDuration = 1f;

            await FadeOutWithDOTween(fadeDuration);

            gameObject.SetActive(false);
        }

        private async Task FadeOutWithDOTween(float fadeDuration)
        {
            Tween fadeTween = Curtain.DOFade(0f, fadeDuration);
            await fadeTween.AsyncWaitForCompletion();
        }
    }
}
