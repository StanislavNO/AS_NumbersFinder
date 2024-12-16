using System;
using UnityEngine;
using Zenject;

namespace Assets.Source.CodeBase.Core.Infrastructure.Services.InputService
{
    internal class StandaloneInput : IInputService, ITickable
    {
        public event Action<Vector2> Clicked;

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector2 clickPosition = Input.mousePosition;
                Clicked?.Invoke(clickPosition);
            }
        }
    }
}
