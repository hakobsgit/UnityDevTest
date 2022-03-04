using UnityEngine;
using UnityEngine.UI;

namespace Interfaces.Views {
	public interface IPopupView {
		Canvas Canvas { get; }

		RectTransform Container { get; }

		Image Dimmer { get; }
	}
}