using Interfaces.Managers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views.Elements {
	[RequireComponent(typeof(Button))]
	public class PopupOpenButton : MonoBehaviour {
		[Inject] private IPopupManager _popupManager;

		public void Open(string popupName) {
			_popupManager.ShowPopup(popupName);
		}
	}
}