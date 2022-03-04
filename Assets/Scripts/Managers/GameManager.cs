using UnityEngine;
using Zenject;

namespace Managers {
	public class GameManager : IInitializable {
		public void Initialize() {
			Application.targetFrameRate = 60;
		}
	}
}