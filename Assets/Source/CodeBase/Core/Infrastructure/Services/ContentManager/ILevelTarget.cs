using System;

namespace Assets.Source.CodeBase.Core.Infrastructure.Services.ContentManager
{
    internal interface ILevelTarget
    {
        event Action TargetChanged;
        string LevelTarget { get; }
    }
}