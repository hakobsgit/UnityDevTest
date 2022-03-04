using Popups.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Popups {
	public class DialogPopup : BasePopup {
		[SerializeField] private TextMeshProUGUI _message;
		[SerializeField] private TextMeshProUGUI _leftButtonText;
		[SerializeField] private TextMeshProUGUI _rightButtonText;
		[SerializeField] private Button _leftButton;
		[SerializeField] private Button _rightButton;

		public void Init(string message, UnityAction leftButtonAction = null, UnityAction rightButtonAction = null) {
			Init(message, "No", "Yes", leftButtonAction, rightButtonAction);
		}

		public void Init(string message, string leftButtonText, string rightButtonText, UnityAction leftButtonAction, UnityAction rightButtonAction) {
			_message.text = message;
			_leftButtonText.text = leftButtonText;
			_rightButtonText.text = rightButtonText;
			_leftButton.onClick.RemoveAllListeners();
			_leftButton.onClick.AddListener(leftButtonAction);
			_rightButton.onClick.RemoveAllListeners();
			_rightButton.onClick.AddListener(rightButtonAction);
		}
	}
}