using Assets.Source.CodeBase.Core.Common.Configs;
using Assets.Source.CodeBase.Core.Infrastructure.Services.TimeManager;
using Assets.Source.CodeBase.View.UI;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Source.CodeBase.Core.Infrastructure.Installers
{
    internal class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private LevelsContainer _levelsContainer;
        [SerializeField] private PrefabsContainer _prefabsContainer;

        public override void InstallBindings()
        {
            BindConfigs();
            BindPauseController();
            BindSceneSwitcher();
        }

        private void BindSceneSwitcher()
        {
            Container
                .BindInterfacesAndSelfTo<SceneSwitcher>()
                .AsSingle();
        }

        private void BindPauseController()
        {
            Container
                .BindInterfacesAndSelsTo<PauseController>()
                .AsSingle();
        }

        private void BindConfigs()
        {
            Container
                .BindInstance(_levelsContainer)
                .AsSingle();

            Container
                .BindInstance(_prefabsContainer)
                .AsSingle();
        }
    }
}