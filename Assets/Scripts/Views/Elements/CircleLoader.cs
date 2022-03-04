using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Elements {
	[RequireComponent(typeof(Image))]
	public class CircleLoader : MonoBehaviour {
		private Image _image;

		public void SetActive(bool active) {
			_image.enabled = active;
			if (active) {
				transform.DORotate(Vector3.forward * 360, 0.3f).SetRelative().SetEase(Ease.Linear).SetLoops(-1);
			}
			else {
				transform.DOKill();
			}
		}

		private void Awake() {
			_image = GetComponent<Image>();
		}
	}
}