namespace Assets.Source.CodeBase.Core.Infrastructure.Services.TimeManager
{
    internal interface IPauseController : IPause
    {
        void Pause();
        void UnPause();
    }
}