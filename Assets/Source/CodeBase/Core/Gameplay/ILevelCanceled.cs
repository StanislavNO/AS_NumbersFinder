using System;

namespace Assets.Source.CodeBase.Core.Gameplay
{
    internal interface ILevelCanceled
    {
        event Action LastLevelPassed;
    }
}