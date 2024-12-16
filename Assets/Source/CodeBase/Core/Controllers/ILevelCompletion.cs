using System;

namespace Assets.Source.CodeBase.Core.Controllers
{
    internal interface ILevelCompletion
    {
        event Action LevelTargetClicked;
        event Action LevelTargetComplied;
    }
}