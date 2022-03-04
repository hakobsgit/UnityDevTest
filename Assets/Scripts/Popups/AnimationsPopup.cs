using Popups.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Popups {
	public class AnimationsPopup : BasePopup {
		[SerializeField] private TextMeshProUGUI _message;
		[SerializeField] private TextMeshProUGUI _buttonText;
		[SerializeField] private Button _button;

		public void Init(string message, string buttonText, UnityAction buttonAction) {
			_message.text = message;
			_buttonText.text = buttonText;
			_button.onClick.RemoveAllListeners();
			_button.onClick.AddListener(buttonAction);
		}
	}
}