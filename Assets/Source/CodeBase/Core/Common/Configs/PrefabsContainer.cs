using Assets.Source.CodeBase.Core.Gameplay;
using Assets.Source.CodeBase.View.UI;
using UnityEngine;

namespace Assets.Source.CodeBase.Core.Common.Configs
{
    [CreateAssetMenu(fileName = "Prefabs", menuName = "PrefabsContainer")]
    public class PrefabsContainer : ScriptableObject
    {
        [field: SerializeField] public Cell Cell { get; private set; }
        [field: SerializeField] public ParticleSystem Particle { get; private set; }
        [field: SerializeField] public LoadingCurtain LoadingCurtain { get; private set; }
    }
}