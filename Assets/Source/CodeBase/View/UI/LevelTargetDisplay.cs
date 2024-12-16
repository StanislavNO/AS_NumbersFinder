using Assets.Source.CodeBase.View.UI;
using TMPro;
using UnityEngine;

public class LevelTargetDisplay : MonoBehaviour , ITargetDisplay
{
    [SerializeField] private TMP_Text _target;
    [field: SerializeField] public CanvasGroup CanvasGroup { get; private set; }

    public Vector2 Position => transform.position;

    public void ShowTarget(string text)
    {
        _target.text = text;
    }
}