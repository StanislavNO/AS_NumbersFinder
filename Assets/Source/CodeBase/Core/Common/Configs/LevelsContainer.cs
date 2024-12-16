using UnityEngine;

namespace Assets.Source.CodeBase.Core.Common.Configs
{
    [CreateAssetMenu(fileName = "LevelsContainer", menuName = "LevelsContainer")]
    internal class LevelsContainer : ScriptableObject
    {
        [field: SerializeField] public Bundle Bundle {get; private set;}
        [field: SerializeField] public Level[] Levels { get; private set; }
    }
}