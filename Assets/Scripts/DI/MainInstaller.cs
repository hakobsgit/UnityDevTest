using Configs.Popups;
using Interfaces.Configs.Popups;
using Managers;
using UnityEngine;
using Zenject;

namespace DI {
	public class MainInstaller : MonoInstaller {
		[SerializeField] private PopupsConfig _popupsConfig;
		public override void InstallBindings() {
			InstallConfigs();
			InstallManagers();
		}

		private void InstallConfigs() {
			Container.Bind<IPopupsConfig>().FromInstance(_popupsConfig).AsSingle();
		}

		private void InstallManagers() {
			Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<PopupManager>().AsSingle().NonLazy();
		}
	}
}