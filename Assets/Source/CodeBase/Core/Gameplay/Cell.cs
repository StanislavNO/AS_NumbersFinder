using Assets.Source.CodeBase.Core.Common.Configs;
using UnityEngine;

namespace Assets.Source.CodeBase.Core.Gameplay
{
    [RequireComponent(typeof(Collider2D))]
    public class Cell : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _contentRenderer;

        [field: SerializeField]
        public Transform Transform { get; private set; }
        [field: SerializeField]
        public Transform ContentTransform { get; private set; }
        public string ItemId { get; private set; }

        private void OnDisable()
        {
            ItemId = null;
        }

        public void Set(Item content)
        {
            _contentRenderer.sprite = content.View;
            ItemId = content.Name;
        }
    }
}