using Interfaces.Views;
using UnityEngine;
using UnityEngine.UI;
using Views.Elements;

namespace Views {
	public class PopupView : MonoBehaviour, IPopupView {
		[SerializeField] private Canvas _canvas;
		[SerializeField] private RectTransform _container;
		[SerializeField] private Image _dimmer;
		[SerializeField] private CircleLoader _loader;

		public Canvas Canvas => _canvas;

		public RectTransform Container => _container;

		public Image Dimmer => _dimmer;

		public CircleLoader Loader => _loader;
	}
}