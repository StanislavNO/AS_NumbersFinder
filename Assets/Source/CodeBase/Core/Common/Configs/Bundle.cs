using UnityEngine;

namespace Assets.Source.CodeBase.Core.Common.Configs
{
    [CreateAssetMenu(fileName = "Bundle", menuName = "Bundle", order = 1)]
    internal class Bundle : ScriptableObject
    {
        [field: SerializeField] public Item[] Items { get; private set; }
    }
}