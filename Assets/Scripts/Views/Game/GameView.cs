using Interfaces.Game;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Views.Game {
	public class GameView : MonoBehaviour, IGameView {
		[SerializeField] private Button _startButton; 
		
		public void Init(UnityAction startButtonAction) {
			_startButton.onClick.RemoveAllListeners();
			_startButton.onClick.AddListener(startButtonAction);
		}
	}
}