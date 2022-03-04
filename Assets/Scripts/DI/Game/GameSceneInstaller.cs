using Controllers;
using Interfaces.Game;
using UnityEngine;
using Views.Game;
using Zenject;

namespace DI.Game {
	public class GameSceneInstaller : MonoInstaller {
		[SerializeField] private GameView _gameView;
		
		public override void InstallBindings() {
			InstallViews();
			InstallControllers();
		}

		private void InstallViews() {
			Container.Bind<IGameView>().FromInstance(_gameView).AsSingle();
		}

		private void InstallControllers() {
			Container.BindInterfacesAndSelfTo<GameController>().AsSingle();
		}
	}
}