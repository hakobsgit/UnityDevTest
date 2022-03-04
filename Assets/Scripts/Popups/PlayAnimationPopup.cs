using DG.Tweening;
using Popups.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Popups {
	public class PlayAnimationPopup : BasePopup {
		[SerializeField] private ParticleSystem _particles;
		[SerializeField] private Button _playButton;

		protected override void Start() {
			base.Start();
			_playButton.onClick.AddListener(() => {
				_playButton.transform.DOShakePosition(0.5f, 10);
				_particles.Play();
			});
		}
	}
}