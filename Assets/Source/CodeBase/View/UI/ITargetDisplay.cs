using UnityEngine;

namespace Assets.Source.CodeBase.View.UI
{
    internal interface ITargetDisplay
    {
        Vector2 Position { get; }
        CanvasGroup CanvasGroup { get; }
        void ShowTarget(string text);
    }
}