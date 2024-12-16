using System;
using UnityEngine;

namespace Assets.Source.CodeBase.Core.Common.Configs
{
    [Serializable]
    internal class Level
    {
        [SerializeField][Range(1,5)] private int _row;
        [SerializeField][Range(1, 5)] private int _column;

        public int Row => _row;
        public int Column => _column;
    }
}