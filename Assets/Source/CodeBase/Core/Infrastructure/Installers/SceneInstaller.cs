using Assets.Source.CodeBase.Core.Controllers;
using Assets.Source.CodeBase.Core.Infrastructure.Services.AnimatorController;
using Assets.Source.CodeBase.Core.Infrastructure.Services.Factories;
using Assets.Source.CodeBase.Core.Infrastructure.Services.Initializers;
using Assets.Source.CodeBase.Core.Infrastructure.Services.InputService;
using Assets.Source.CodeBase.Core.Infrastructure.Services.Score;
using Assets.Source.CodeBase.View.UI;
using UnityEngine;
using Zenject;

namespace Assets.Source.CodeBase.Core.Infrastructure.Installers
{
    internal class SceneInstaller : MonoInstaller
    {
        [SerializeField] private LevelTargetDisplay _targetView;
        [SerializeField] private GameOverDisplay _gameOverDisplay;

        public override void InstallBindings()
        {
            BindView();
            BindInputService();
            BindAnimationService();
            BindFactory();
            BindContentProvider();
            BindSpawner();
            BindControllers();
        }

        private void BindView()
        {
            Container
                .BindInterfacesAndSelsTo<LevelTargetDisplay>()
                .FromInstance(_targetView)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<GameOverDisplay>()
                .FromInstance(_gameOverDisplay)
                .AsSingle();
        }

        private void BindInputService()
        {
            Container
                .BindInterfacesAndSelsTo<StandaloneInput>()
                .AsSingle();
        }

        private void BindAnimationService()
        {
            Container
                .Bind<IAnimationService>()
                .To<AnimationController>()
                .AsSingle();
        }

        private void BindContentProvider()
        {
            Container
                .BindInterfacesAndSelsTo<ContentProvider>()
                .AsSingle();
        }

        private void BindControllers()
        {
            Container
                .BindInterfacesAndSelsTo<GameStarter>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelsTo<PlayerInputController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelsTo<ViewController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelsTo<LevelSwitchController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelsTo<GameOverController>()
                .AsSingle()
                .NonLazy();
        }

        private void BindSpawner()
        {
            Container
                 .BindInterfacesAndSelfTo<CellSpawner>()
                 .AsSingle();
        }

        private void BindFactory()
        {
            Container
                .BindInterfacesAndSelfTo<CellInitializer>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<GridFactory>()
                .AsSingle();
        }
    }
}