
using UnityEngine;

namespace Assets.Source.CodeBase.Core.Infrastructure.Services.TimeManager
{
    internal class PauseController : IPauseController
    {
        public bool IsGame { get; private set; }

        public PauseController()
        {
            IsGame = true;
        }

        public void UnPause()
        {
            IsGame = true;
        }

        public void Pause()
        {
            IsGame = false;
        }
    }
}