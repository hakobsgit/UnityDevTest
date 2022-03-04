using Popups.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Popups {
	public class AddressablePopup : BasePopup {
		[SerializeField] private TextMeshProUGUI _buttonText;
		[SerializeField] private Button _button;

		public void Init(string buttonText, UnityAction buttonAction, bool enableCloseButton = true) {
			_buttonText.text = buttonText;
			SetCloseButtonActive(enableCloseButton);
			_button.onClick.RemoveAllListeners();
			_button.onClick.AddListener(buttonAction);
		}
	}
}