using System;
using UnityEngine;

namespace Assets.Source.CodeBase.Core.Infrastructure.Services.AnimatorController
{
    internal interface IAnimationService
    {
        void FadeOut(CanvasGroup view);
        void FadeIn(CanvasGroup view);
        void ShowBounds(Transform obj);
        void Vibration(Transform obj);
        void Rotation(Transform obj, Action complied);
        void SpawnParticle(Vector2 position);
    }
}