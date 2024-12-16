using UnityEngine;

namespace Assets.Source.CodeBase.Core.Common.Configs
{
    [CreateAssetMenu(fileName = "new Item", menuName = "Item")]
    public class Item : ScriptableObject
    {
        [field: SerializeField] public string Name{get; private set;}
        [field: SerializeField] public Sprite View{get; private set;}
    }
}