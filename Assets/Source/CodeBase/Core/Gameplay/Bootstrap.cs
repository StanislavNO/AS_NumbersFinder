using Zenject;

namespace Assets.Source.CodeBase.Core.Gameplay
{
    internal class Bootstrap : IInitializable
    {
        private readonly SceneSwitcher _sceneSwitcher;

        public Bootstrap(SceneSwitcher sceneSwitcher)
        {
            _sceneSwitcher = sceneSwitcher;
        }

        public void Initialize()
        {
            _sceneSwitcher.LoadGameAsync();
        }
    }
}
