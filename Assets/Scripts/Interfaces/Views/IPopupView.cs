using UnityEngine;
using UnityEngine.UI;
using Views.Elements;

namespace Interfaces.Views {
	public interface IPopupView {
		Canvas Canvas { get; }

		RectTransform Container { get; }

		Image Dimmer { get; }
		CircleLoader Loader { get; }
	}
}