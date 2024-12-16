using System;
using UnityEngine;

namespace Assets.Source.CodeBase.Core.Infrastructure.Services.InputService
{
    internal interface IInputService
    {
        event Action<Vector2> Clicked;
    }
}