using Assets.Source.CodeBase.Core.Gameplay;
using Assets.Source.CodeBase.View.UI;
using UnityEngine;
using Zenject;

namespace Assets.Source.CodeBase.Core.Infrastructure.Installers
{
    internal class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;

        public override void InstallBindings()
        {
            BindLoadingCurtain();
            BindBootstrap();
        }

        private void BindBootstrap()
        {
            Container
                .BindInterfacesAndSelfTo<Bootstrap>()
                .AsSingle()
                .NonLazy();
        }

        private void BindLoadingCurtain()
        {
            Container
                .BindInstance(_loadingCurtain)
                .AsSingle()
                .NonLazy();
        }
    }
}
