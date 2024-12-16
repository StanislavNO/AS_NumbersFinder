using Assets.Source.CodeBase.Core.Common.Configs;
using DG.Tweening;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Source.CodeBase.Core.Infrastructure.Services.AnimatorController
{
    internal class AnimationController : IAnimationService
    {
        private readonly GameObject _particle;

        public AnimationController(PrefabsContainer prefabsContainer)
        {
            _particle = prefabsContainer.Particle.gameObject;
        }

        public void FadeOut(CanvasGroup view)
        {
            view.DOFade(0, 0.5f);
        }

        public void FadeIn(CanvasGroup view)
        {
            view.alpha = 0;
            view.DOFade(1, 2.5f);
        }

        public void ShowBounds(Transform obj)
        {
            obj.DOScale(1, 1.3f)
                .From(0).SetEase(Ease.OutBounce);
        }

        public void Rotation(Transform obj, Action complied)
        {
            float duration = 2f;

            obj.DORotate(new Vector3(0f, 360f, 0f), duration, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    obj.rotation = Quaternion.identity;
                    complied?.Invoke();
                });
        }

        public void Vibration(Transform obj)
        {
            float shakeDuration = 1f;
            float shakeStrength = 0.1f;
            int shakeVibrato = 10;

            Sequence shakeSequence = DOTween.Sequence();

            shakeSequence.Append(obj.DOShakePosition(
                duration: shakeDuration,
                strength: new Vector3(shakeStrength, 0, 0),
                vibrato: shakeVibrato,
                randomness: 0,
                snapping: false,
                fadeOut: true
            ));

            shakeSequence.Append(obj.DOMove(obj.position, 0f));
            shakeSequence.Play();
        }

        public void SpawnParticle(Vector2 position)
        {
            float liveTime = 2f;

            GameObject starEffect = Object.Instantiate(_particle, position, Quaternion.identity);

            Object.Destroy(starEffect, liveTime);
        }
    }
}